using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Dcl{

	public class DclPrimitiveMeshBuilder{

		static public Mesh BuildConeOrCylinder(int numVertices, float radiusTop, float radiusBottom, float length,
			float openingAngle, bool outside, bool inside, bool isCylinder, Vector3 offsetPos=default(Vector3)) 
		{
			if(openingAngle>0&&openingAngle<180){
				radiusTop=0;
				radiusBottom=length*Mathf.Tan(openingAngle*Mathf.Deg2Rad/2);
			}
			string meshName = isCylinder ? "Cylinder" : "Cone" + numVertices + "v" + radiusTop + "t" + radiusBottom + "b" + length + "l" + length + (outside?"o":"") + (inside?"i":"");
			//string meshPrefabPath = "Assets/Decentraland/Internal/" + meshName + ".asset";
			Mesh mesh = null;//(Mesh)AssetDatabase.LoadAssetAtPath(meshPrefabPath, typeof(Mesh));
			if(mesh==null){
				mesh=new Mesh();
				mesh.name=meshName;
				// can't access Camera.current
				//newCone.transform.position = Camera.current.transform.position + Camera.current.transform.forward * 5.0f;
				int multiplier=(outside?1:0)+(inside?1:0);
				int offset=(outside&&inside?2*numVertices:0);

				bool bTopCap = isCylinder ? true : false;
				bool bBottomCap = true;

				Vector3[] vertices=new Vector3[2*multiplier*numVertices+(bTopCap ? (numVertices+1) : 0) + (bBottomCap ? (numVertices+1) : 0)]; // 0..n-1: top, n..2n-1: bottom
				Vector3[] normals=new Vector3[2*multiplier*numVertices+(bTopCap ? (numVertices+1) : 0) + (bBottomCap ? (numVertices+1) : 0)];
				Vector2[] uvs=new Vector2[2*multiplier*numVertices+(bTopCap ? (numVertices+1) : 0) + (bBottomCap ? (numVertices+1) : 0)];
				int[] tris;
				float slope=Mathf.Atan((radiusBottom-radiusTop)/length); // (rad difference)/height
				float slopeSin=Mathf.Sin(slope);
				float slopeCos=Mathf.Cos(slope);
				int i;

				for(i=0;i<numVertices;i++){
					float angle=2*Mathf.PI*i/numVertices;
					float angleSin=Mathf.Sin(angle);
					float angleCos=Mathf.Cos(angle);
					float angleHalf=2*Mathf.PI*(i+0.5f)/numVertices; // for degenerated normals at cone tips
					float angleHalfSin=Mathf.Sin(angleHalf);
					float angleHalfCos=Mathf.Cos(angleHalf);

					//vertices[i]=new Vector3(radiusTop*angleCos,radiusTop*angleSin,0);
					//vertices[i+numVertices]=new Vector3(radiusBottom*angleCos,radiusBottom*angleSin,length);

					vertices[i]=new Vector3(radiusTop*angleCos,length,radiusTop*angleSin)+offsetPos;
					vertices[i+numVertices]=new Vector3(radiusBottom*angleCos,0,radiusBottom*angleSin)+offsetPos;

					if(radiusTop==0)
						normals[i]=new Vector3(angleHalfCos*slopeCos,-slopeSin,angleHalfSin*slopeCos);
					else
						normals[i]=new Vector3(angleCos*slopeCos,-slopeSin,angleSin*slopeCos);
					
					if(radiusBottom==0)
						normals[i+numVertices]=new Vector3(angleHalfCos*slopeCos,-slopeSin,angleHalfSin*slopeCos);
					else
						normals[i+numVertices]=new Vector3(angleCos*slopeCos,-slopeSin,angleSin*slopeCos);

					uvs[i]=new Vector2(1.0f-1.0f*i/numVertices,1);
					uvs[i+numVertices]=new Vector2(1.0f-1.0f*i/numVertices,0);

					if(outside&&inside){
						// vertices and uvs are identical on inside and outside, so just copy
						vertices[i+2*numVertices]=vertices[i];
						vertices[i+3*numVertices]=vertices[i+numVertices];
						uvs[i+2*numVertices]=uvs[i];
						uvs[i+3*numVertices]=uvs[i+numVertices];
					}
					if(inside){
						// invert normals
						normals[i+offset]=-normals[i];
						normals[i+numVertices+offset]=-normals[i+numVertices];
					}
				}

				int coverTopIndexStart = 2 * multiplier * numVertices;
				int coverTopIndexEnd = 2*multiplier*numVertices+numVertices;

				if (bTopCap) {
					for (i = 0; i < numVertices; i++) {
						float angle=2*Mathf.PI*i/numVertices;
						float angleSin=Mathf.Sin(angle);
						float angleCos=Mathf.Cos(angle);

						vertices[coverTopIndexStart+i]=new Vector3(radiusTop*angleCos,length,radiusTop*angleSin)+offsetPos;
						normals [coverTopIndexStart+i] = new Vector3 (0, 1, 0);
						uvs [coverTopIndexStart+i] = new Vector2 (angleCos/2+0.5f, angleSin/2+0.5f);
					}

					vertices [coverTopIndexStart + numVertices] = new Vector3 (0, length, 0)+offsetPos;
					normals [coverTopIndexStart + numVertices] = new Vector3 (0, 1, 0);
					uvs [coverTopIndexStart + numVertices] = new Vector2 (0.5f, 0.5f);
				}


				int coverBottomIndexStart = coverTopIndexStart + (bTopCap ? 1 : 0)*(numVertices+1);
				int coverBottomIndexEnd = coverBottomIndexStart + numVertices;
				if (bBottomCap) {
					for (i = 0; i < numVertices; i++) {
						float angle=2*Mathf.PI*i/numVertices;
						float angleSin=Mathf.Sin(angle);
						float angleCos=Mathf.Cos(angle);

						vertices[coverBottomIndexStart+i]=new Vector3(radiusBottom*angleCos,0f,radiusBottom*angleSin)+offsetPos;
						normals [coverBottomIndexStart+i] = new Vector3 (0, -1, 0);
						uvs [coverBottomIndexStart+i] = new Vector2 (angleCos/2+0.5f, angleSin/2+0.5f);

					}

					vertices [coverBottomIndexStart + numVertices] = new Vector3 (0, 0f, 0)+offsetPos;
					normals [coverBottomIndexStart + numVertices] = new Vector3 (0, -1, 0);
					uvs [coverBottomIndexStart + numVertices] = new Vector2 (0.5f, 0.5f);
				}

				mesh.vertices = vertices;
				mesh.normals = normals;		
				mesh.uv = uvs;

				// create triangles
				// here we need to take care of point order, depending on inside and outside
				int cnt=0;
				if(radiusTop==0){
					// top cone
					tris=new int[numVertices*3*multiplier+((bTopCap ? 1 : 0) * numVertices*3) + ((bBottomCap ? 1 : 0) * numVertices*3)];
					if(outside)
						for(i=0;i<numVertices;i++){
							tris[cnt++]=i+numVertices;
							tris[cnt++]=i;
							if(i==numVertices-1)
								tris[cnt++]=numVertices;
							else
								tris[cnt++]=i+1+numVertices;
						}
					if(inside)
						for(i=offset;i<numVertices+offset;i++){
							tris[cnt++]=i;
							tris[cnt++]=i+numVertices;
							if(i==numVertices-1+offset)
								tris[cnt++]=numVertices+offset;
							else
								tris[cnt++]=i+1+numVertices;
						}
				}else if(radiusBottom==0){
					// bottom cone
					tris=new int[numVertices*3*multiplier+((bTopCap ? 1 : 0) * numVertices*3) + ((bBottomCap ? 1 : 0) * numVertices*3)];
					if(outside)
						for(i=0;i<numVertices;i++){
							tris[cnt++]=i;
							if(i==numVertices-1)
								tris[cnt++]=0;
							else
								tris[cnt++]=i+1;
							tris[cnt++]=i+numVertices;
						}
					if(inside)
						for(i=offset;i<numVertices+offset;i++){
							if(i==numVertices-1+offset)
								tris[cnt++]=offset;
							else
								tris[cnt++]=i+1;
							tris[cnt++]=i;
							tris[cnt++]=i+numVertices;
						}
				}else{
					// truncated cone
					tris=new int[numVertices*6*multiplier+ ((bTopCap ? 1 : 0) * numVertices*3) + ((bBottomCap ? 1 : 0) * numVertices*3)];
					if(outside)
						for(i=0;i<numVertices;i++){
							int ip1=i+1;
							if(ip1==numVertices)
								ip1=0;

							tris[cnt++]=i;
							tris[cnt++]=ip1;
							tris[cnt++]=i+numVertices;

							tris[cnt++]=ip1+numVertices;
							tris[cnt++]=i+numVertices;
							tris[cnt++]=ip1;
						}
					if(inside)
						for(i=offset;i<numVertices+offset;i++){
							int ip1=i+1;
							if(ip1==numVertices+offset)
								ip1=offset;

							tris[cnt++]=ip1;
							tris[cnt++]=i;
							tris[cnt++]=i+numVertices;

							tris[cnt++]=i+numVertices;
							tris[cnt++]=ip1+numVertices;
							tris[cnt++]=ip1;
						}

				}

				if (bTopCap) {
					for (i = 0; i < numVertices; ++i) {
						int next = coverTopIndexStart + i + 1;
						if (next == coverTopIndexEnd) {
							next = coverTopIndexStart;
						}

						tris [cnt++] = next;
						tris [cnt++] = coverTopIndexStart+i;
						tris [cnt++] = coverTopIndexEnd;
					}
				}

				if (bBottomCap) {
					for (i = 0; i < numVertices; ++i) {
						int next = coverBottomIndexStart + i + 1;
						if (next == coverBottomIndexEnd) {
							next = coverBottomIndexStart;
						}

						tris [cnt++] = coverBottomIndexEnd;
						tris [cnt++] = coverBottomIndexStart+i;
						tris [cnt++] = next;
					}
				}

				mesh.triangles = tris;		
				//AssetDatabase.CreateAsset(mesh, meshPrefabPath);
				//AssetDatabase.SaveAssets();
			}

			return mesh;
		}

		static public Mesh BuildCone(int numVertices, float radiusTop, float radiusBottom, float length,
			float openingAngle, bool outside, bool inside){
			return BuildConeOrCylinder (numVertices, radiusTop, radiusBottom, length, openingAngle, outside, inside, false);
		}
	
		static public Mesh BuildCylinder(int numVertices, float radiusTop, float radiusBottom, float length,
			float openingAngle, bool outside, bool inside){ 
			return BuildConeOrCylinder (numVertices, radiusTop, radiusBottom, length, openingAngle, outside, inside, true, new Vector3(0f, -length/2, 0f));
		}
	}


}


