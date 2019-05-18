var entity12448 = new Entity("Main Camera")
engine.addEntity(entity12448)
entity12448.addComponent(new Transform({ position: new Vector3(0, 1, -10) }))
entity12448.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12448.getComponent(Transform).scale.set(1, 1, 1)

var entity12270 = new Entity("Directional Light")
engine.addEntity(entity12270)
entity12270.addComponent(new Transform({ position: new Vector3(1.341, 6.197, -2.323) }))
entity12270.getComponent(Transform).rotation.set(0.4082179, -0.2345697, 0.1093816, 0.8754261)
entity12270.getComponent(Transform).scale.set(1, 1, 1)

var entity13042 = new Entity("Frame")
engine.addEntity(entity13042)
entity13042.addComponent(new Transform({ position: new Vector3(15, 0, 5) }))
entity13042.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity13042.getComponent(Transform).scale.set(1, 1, 1)

var entity12610 = new Entity("plane")
entity12610.setParent(entity13042)
entity12610.addComponent(new Transform({ position: new Vector3(-5, 3.68928, -4.97) }))
entity12610.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12610.getComponent(Transform).scale.set(19.94, 0.8, 1)
entity12610.addComponent(new PlaneShape())
entity12610.getComponent(PlaneShape).withCollisions = true

var entity12632 = new Entity("plane (1)")
entity12632.setParent(entity13042)
entity12632.addComponent(new Transform({ position: new Vector3(-5, 3.68928, 4.97) }))
entity12632.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12632.getComponent(Transform).scale.set(19.94, 0.8, 1)
entity12632.addComponent(new PlaneShape())
entity12632.getComponent(PlaneShape).withCollisions = true

var entity12358 = new Entity("plane (2)")
entity12358.setParent(entity13042)
entity12358.addComponent(new Transform({ position: new Vector3(-14.97, 3.68928, 0) }))
entity12358.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity12358.getComponent(Transform).scale.set(9.970012, 0.8, 1)
entity12358.addComponent(new PlaneShape())
entity12358.getComponent(PlaneShape).withCollisions = true

var entity13058 = new Entity("plane (3)")
entity13058.setParent(entity13042)
entity13058.addComponent(new Transform({ position: new Vector3(4.97, 3.68928, 0) }))
entity13058.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity13058.getComponent(Transform).scale.set(9.970012, 0.8, 1)
entity13058.addComponent(new PlaneShape())
entity13058.getComponent(PlaneShape).withCollisions = true

var entity12390 = new Entity("column")
entity12390.setParent(entity13042)
entity12390.addComponent(new Transform({ position: new Vector3(-14.958, 2, -4.95) }))
entity12390.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12390.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity12390.addComponent(new BoxShape())
entity12390.getComponent(BoxShape).withCollisions = true

var entity13108 = new Entity("column (1)")
entity13108.setParent(entity13042)
entity13108.addComponent(new Transform({ position: new Vector3(-4.956539, 2, -4.95) }))
entity13108.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity13108.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity13108.addComponent(new BoxShape())
entity13108.getComponent(BoxShape).withCollisions = true

var entity12882 = new Entity("column (2)")
entity12882.setParent(entity13042)
entity12882.addComponent(new Transform({ position: new Vector3(4.935, 2, -4.95) }))
entity12882.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12882.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity12882.addComponent(new BoxShape())
entity12882.getComponent(BoxShape).withCollisions = true

var entity12288 = new Entity("column (4)")
entity12288.setParent(entity13042)
entity12288.addComponent(new Transform({ position: new Vector3(-14.958, 2, 4.952) }))
entity12288.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12288.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity12288.addComponent(new BoxShape())
entity12288.getComponent(BoxShape).withCollisions = true

var entity12844 = new Entity("column (5)")
entity12844.setParent(entity13042)
entity12844.addComponent(new Transform({ position: new Vector3(-4.956539, 2, 4.952) }))
entity12844.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12844.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity12844.addComponent(new BoxShape())
entity12844.getComponent(BoxShape).withCollisions = true

var entity13098 = new Entity("column (6)")
entity13098.setParent(entity13042)
entity13098.addComponent(new Transform({ position: new Vector3(4.935, 2, 4.952) }))
entity13098.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity13098.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity13098.addComponent(new BoxShape())
entity13098.getComponent(BoxShape).withCollisions = true

var entity12688 = new Entity("plane (4)")
entity12688.setParent(entity13042)
entity12688.addComponent(new Transform({ position: new Vector3(-5, 3.5, -4.98) }))
entity12688.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12688.getComponent(Transform).scale.set(19.94, 0.04, 1)
entity12688.addComponent(new PlaneShape())
entity12688.getComponent(PlaneShape).withCollisions = true
var material11898 = new Material()
material11898.albedoColor = new Color3(0, 0, 0)
material11898.metallic = 0
material11898.roughness = 0.5
material11898.emissiveColor = new Color3(0.04313726, 0, 0.1872549)
entity12688.addComponent(material11898)

var entity12348 = new Entity("plane (5)")
entity12348.setParent(entity13042)
entity12348.addComponent(new Transform({ position: new Vector3(-5, 3.5, 4.98) }))
entity12348.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12348.getComponent(Transform).scale.set(19.94, 0.04, 1)
entity12348.addComponent(new PlaneShape())
entity12348.getComponent(PlaneShape).withCollisions = true
entity12348.addComponent(material11898)

var entity13032 = new Entity("plane (6)")
entity13032.setParent(entity13042)
entity13032.addComponent(new Transform({ position: new Vector3(-14.98, 3.5, 0) }))
entity13032.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity13032.getComponent(Transform).scale.set(9.970014, 0.04, 1)
entity13032.addComponent(new PlaneShape())
entity13032.getComponent(PlaneShape).withCollisions = true
entity13032.addComponent(material11898)

var entity13118 = new Entity("plane (7)")
entity13118.setParent(entity13042)
entity13118.addComponent(new Transform({ position: new Vector3(4.98, 3.5, 0) }))
entity13118.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity13118.getComponent(Transform).scale.set(9.970014, 0.04, 1)
entity13118.addComponent(new PlaneShape())
entity13118.getComponent(PlaneShape).withCollisions = true
entity13118.addComponent(material11898)

var entity12642 = new Entity("Title")
entity12642.setParent(entity13042)
entity12642.addComponent(new Transform({ position: new Vector3(-10, 3.755, -4.999) }))
entity12642.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12642.getComponent(Transform).scale.set(0.1846309, 0.1846309, 0.1846309)
entity12642.addComponent(new TextShape())
entity12642.getComponent(TextShape).value = "DCL\ UNITY\ EXPORTER"
entity12642.getComponent(TextShape).color = new Color3(0.172549, 0, 0.7490196)
entity12642.getComponent(TextShape).width = 32
entity12642.getComponent(TextShape).height = 5.3625
entity12642.getComponent(TextShape).fontSize = 912

var entity12480 = new Entity("Title (1)")
entity12480.setParent(entity13042)
entity12480.addComponent(new Transform({ position: new Vector3(0, 3.755, -4.999) }))
entity12480.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12480.getComponent(Transform).scale.set(0.1846309, 0.1846309, 0.1846309)
entity12480.addComponent(new TextShape())
entity12480.getComponent(TextShape).value = "DCL\ UNITY\ EXPORTER"
entity12480.getComponent(TextShape).color = new Color3(0.172549, 0, 0.7490196)
entity12480.getComponent(TextShape).width = 32
entity12480.getComponent(TextShape).height = 5.3625
entity12480.getComponent(TextShape).fontSize = 912

var entity12982 = new Entity("roof")
entity12982.setParent(entity13042)
entity12982.addComponent(new Transform({ position: new Vector3(-5, 4.1, 0) }))
entity12982.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity12982.getComponent(Transform).scale.set(19.97, 9.98, 1)
entity12982.addComponent(new PlaneShape())
entity12982.getComponent(PlaneShape).withCollisions = true

var entity12604 = new Entity("Front desk")
engine.addEntity(entity12604)
entity12604.addComponent(new Transform({ position: new Vector3(7.106, 0.5, 0.343) }))
entity12604.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12604.getComponent(Transform).scale.set(1, 1, 1)

var entity12824 = new Entity("plane")
entity12824.setParent(entity12604)
entity12824.addComponent(new Transform({ position: new Vector3(-1, 0.06, -0.3309999) }))
entity12824.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12824.getComponent(Transform).scale.set(0.5617885, 0.5617885, 0.5617885)
entity12824.addComponent(new PlaneShape())
entity12824.getComponent(PlaneShape).withCollisions = true
var material11834 = new Material()
material11834.albedoColor = new Color3(0, 0, 0)
material11834.metallic = 0
material11834.roughness = 0.5
material11834.emissiveColor = new Color3(1, 1, 1)
material11834.emissiveTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/fairwood_logo.jpg")
entity12824.addComponent(material11834)

var entity12732 = new Entity("Table")
entity12732.setParent(entity12604)
entity12732.addComponent(new Transform({ position: new Vector3(0, 0, 0) }))
entity12732.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12732.getComponent(Transform).scale.set(3.0906, 1, 0.6410449)
entity12732.addComponent(new BoxShape())
entity12732.getComponent(BoxShape).withCollisions = true
var material11664 = new Material()
material11664.albedoColor = new Color3(0.8962264, 0.8938915, 0.875089)
material11664.metallic = 0
material11664.roughness = 0.11
entity12732.addComponent(material11664)

var entity12504 = new Entity("plane (8)")
entity12504.setParent(entity12732)
entity12504.addComponent(new Transform({ position: new Vector3(0.001, -0.345, -0.5038648) }))
entity12504.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12504.getComponent(Transform).scale.set(1, 0.04, 1.559953)
entity12504.addComponent(new PlaneShape())
entity12504.getComponent(PlaneShape).withCollisions = true
entity12504.addComponent(material11898)

var entity12942 = new Entity("Text")
entity12942.setParent(entity12604)
entity12942.addComponent(new Transform({ position: new Vector3(0.355, 0.04500002, -0.342) }))
entity12942.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12942.getComponent(Transform).scale.set(0.133473, 0.133473, 0.133473)
entity12942.addComponent(new TextShape())
entity12942.getComponent(TextShape).value = "FAIRWOOD"
entity12942.getComponent(TextShape).color = new Color3(0, 0.4627451, 0.09803922)
entity12942.getComponent(TextShape).width = 26.6
entity12942.getComponent(TextShape).height = 5.3625
entity12942.getComponent(TextShape).fontSize = 912

var entity12540 = new Entity("Map Board")
engine.addEntity(entity12540)
entity12540.addComponent(new Transform({ position: new Vector3(1.59, 0, 1.016) }))
entity12540.getComponent(Transform).rotation.set(0, -0.2588186, 0, 0.965926)
entity12540.getComponent(Transform).scale.set(1.3902, 1.3902, 1.3902)

var entity12854 = new Entity("plane")
entity12854.setParent(entity12540)
entity12854.addComponent(new Transform({ position: new Vector3(0, 1.065, 0) }))
entity12854.getComponent(Transform).rotation.set(0.05113563, 0, 0, 0.9986918)
entity12854.getComponent(Transform).scale.set(1, 1, 1)
entity12854.addComponent(new PlaneShape())
entity12854.getComponent(PlaneShape).withCollisions = true
var material11750 = new Material()
material11750.albedoColor = new Color3(1, 1, 1)
material11750.metallic = 0
material11750.roughness = 0.5
material11750.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/dcl_map.png")
entity12854.addComponent(material11750)

var entity12962 = new Entity("column (8)")
entity12962.setParent(entity12540)
entity12962.addComponent(new Transform({ position: new Vector3(-0.25, 0.4, -0.03399992) }))
entity12962.getComponent(Transform).rotation.set(0.03848108, 0.00307059, -0.0794827, 0.9960885)
entity12962.getComponent(Transform).scale.set(0.04000001, 0.8256255, 0.03999999)
entity12962.addComponent(new BoxShape())
entity12962.getComponent(BoxShape).withCollisions = true

var entity13004 = new Entity("column (9)")
entity13004.setParent(entity12540)
entity13004.addComponent(new Transform({ position: new Vector3(0.25, 0.4, -0.034) }))
entity13004.getComponent(Transform).rotation.set(0.03848109, -0.003070428, 0.07947849, 0.9960889)
entity13004.getComponent(Transform).scale.set(0.04000001, 0.8256252, 0.03999999)
entity13004.addComponent(new BoxShape())
entity13004.getComponent(BoxShape).withCollisions = true

var entity12620 = new Entity("column (10)")
entity12620.setParent(entity12540)
entity12620.addComponent(new Transform({ position: new Vector3(0, 0.392, 0.205) }))
entity12620.getComponent(Transform).rotation.set(-0.2456335, 0, 0, 0.9693628)
entity12620.getComponent(Transform).scale.set(0.04, 0.8888682, 0.04)
entity12620.addComponent(new BoxShape())
entity12620.getComponent(BoxShape).withCollisions = true

var entity12438 = new Entity("column (11)")
entity12438.setParent(entity12540)
entity12438.addComponent(new Transform({ position: new Vector3(0, 0.788, -0.004) }))
entity12438.getComponent(Transform).rotation.set(0, 0, 0.7071058, 0.7071078)
entity12438.getComponent(Transform).scale.set(0.04000001, 0.6386578, 0.03999999)
entity12438.addComponent(new BoxShape())
entity12438.getComponent(BoxShape).withCollisions = true

var entity12432 = new Entity("Area0")
engine.addEntity(entity12432)
entity12432.addComponent(new Transform({ position: new Vector3(3.38, 0, 5) }))
entity12432.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12432.getComponent(Transform).scale.set(1, 1, 1)

var entity12534 = new Entity("Frame")
entity12534.setParent(entity12432)
entity12534.addComponent(new Transform({ position: new Vector3(1.93, 0, 0) }))
entity12534.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12534.getComponent(Transform).scale.set(1, 1, 1)

var entity12762 = new Entity("cylinder")
entity12762.setParent(entity12534)
entity12762.addComponent(new Transform({ position: new Vector3(-3.43, 0.4, -1.532) }))
entity12762.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12762.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity12762.addComponent(new CylinderShape())
entity12762.getComponent(CylinderShape).withCollisions = true
var material11952 = new Material()
material11952.albedoColor = new Color3(0.3962264, 0.307827, 0.07662868)
material11952.metallic = 1
material11952.roughness = 0.331
entity12762.addComponent(material11952)

var entity12258 = new Entity("cylinder (1)")
entity12258.setParent(entity12534)
entity12258.addComponent(new Transform({ position: new Vector3(5.57, 0.4, -1.532) }))
entity12258.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12258.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity12258.addComponent(new CylinderShape())
entity12258.getComponent(CylinderShape).withCollisions = true
entity12258.addComponent(material11952)

var entity13068 = new Entity("cylinder (2)")
entity13068.setParent(entity12534)
entity13068.addComponent(new Transform({ position: new Vector3(-3.43, 0.4, 0.89) }))
entity13068.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity13068.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity13068.addComponent(new CylinderShape())
entity13068.getComponent(CylinderShape).withCollisions = true
entity13068.addComponent(material11952)

var entity12314 = new Entity("cylinder (3)")
entity12314.setParent(entity12534)
entity12314.addComponent(new Transform({ position: new Vector3(5.57, 0.4, 0.89) }))
entity12314.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12314.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity12314.addComponent(new CylinderShape())
entity12314.getComponent(CylinderShape).withCollisions = true
entity12314.addComponent(material11952)

var entity12338 = new Entity("Tape")
entity12338.setParent(entity12534)
entity12338.addComponent(new Transform({ position: new Vector3(1.07, 0.65, -1.532) }))
entity12338.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12338.getComponent(Transform).scale.set(8.986068, 0.08110655, 1)
entity12338.addComponent(new PlaneShape())
var material11896 = new Material()
material11896.albedoColor = new Color3(0.3701339, 0.3436276, 0.6226415)
material11896.metallic = 0
material11896.roughness = 0.5
material11896.hasAlpha = true
material11896.alpha = 0.2784314
entity12338.addComponent(material11896)

var entity12752 = new Entity("Title (4)")
entity12752.setParent(entity12338)
entity12752.addComponent(new Transform({ position: new Vector3(-0.3521428, 0, -0.004700065) }))
entity12752.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12752.getComponent(Transform).scale.set(0.004800823, 0.4143409, 0.03360576)
entity12752.addComponent(new TextShape())
entity12752.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity12752.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity12752.getComponent(TextShape).width = 32
entity12752.getComponent(TextShape).height = 5.3625
entity12752.getComponent(TextShape).fontSize = 912

var entity12594 = new Entity("Title (5)")
entity12594.setParent(entity12338)
entity12594.addComponent(new Transform({ position: new Vector3(-0.1297143, 0, -0.004700065) }))
entity12594.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12594.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity12594.addComponent(new TextShape())
entity12594.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity12594.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity12594.getComponent(TextShape).width = 32
entity12594.getComponent(TextShape).height = 5.3625
entity12594.getComponent(TextShape).fontSize = 912

var entity12742 = new Entity("Title (6)")
entity12742.setParent(entity12338)
entity12742.addComponent(new Transform({ position: new Vector3(0.08285712, 0, -0.004700065) }))
entity12742.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12742.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity12742.addComponent(new TextShape())
entity12742.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity12742.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity12742.getComponent(TextShape).width = 32
entity12742.getComponent(TextShape).height = 5.3625
entity12742.getComponent(TextShape).fontSize = 912

var entity12410 = new Entity("Title (7)")
entity12410.setParent(entity12338)
entity12410.addComponent(new Transform({ position: new Vector3(0.282, 0, -0.004700065) }))
entity12410.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12410.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity12410.addComponent(new TextShape())
entity12410.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity12410.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity12410.getComponent(TextShape).width = 32
entity12410.getComponent(TextShape).height = 5.3625
entity12410.getComponent(TextShape).fontSize = 912

var entity12814 = new Entity("Tape (1)")
entity12814.setParent(entity12534)
entity12814.addComponent(new Transform({ position: new Vector3(1.07, 0.65, 0.89) }))
entity12814.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity12814.getComponent(Transform).scale.set(8.986068, 0.08111, 1)
entity12814.addComponent(new PlaneShape())
entity12814.addComponent(material11896)

var entity12902 = new Entity("Tape (2)")
entity12902.setParent(entity12534)
entity12902.addComponent(new Transform({ position: new Vector3(-3.427, 0.65, -0.323) }))
entity12902.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity12902.getComponent(Transform).scale.set(2.389797, 0.08111, 1)
entity12902.addComponent(new PlaneShape())
entity12902.addComponent(material11896)

var entity13088 = new Entity("Tape (3)")
entity13088.setParent(entity12534)
entity13088.addComponent(new Transform({ position: new Vector3(5.572, 0.65, -0.323) }))
entity13088.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity13088.getComponent(Transform).scale.set(2.389802, 0.08111, 1)
entity13088.addComponent(new PlaneShape())
entity13088.addComponent(material11896)

var entity12698 = new Entity("box")
entity12698.setParent(entity12432)
entity12698.addComponent(new Transform({ position: new Vector3(-0.661, 0, -1.064) }))
entity12698.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12698.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity12698.addComponent(new BoxShape())
entity12698.getComponent(BoxShape).withCollisions = true

var entity12792 = new Entity("Text")
entity12792.setParent(entity12698)
entity12792.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity12792.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12792.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity12792.addComponent(new TextShape())
entity12792.getComponent(TextShape).value = "box"
entity12792.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12792.getComponent(TextShape).width = 7.6
entity12792.getComponent(TextShape).height = 3.79186
entity12792.getComponent(TextShape).fontSize = 912

var entity12834 = new Entity("box (1)")
entity12834.setParent(entity12432)
entity12834.addComponent(new Transform({ position: new Vector3(0.689, 0, -1.064) }))
entity12834.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12834.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity12834.addComponent(new BoxShape())
entity12834.getComponent(BoxShape).withCollisions = true

var entity12872 = new Entity("Text")
entity12872.setParent(entity12834)
entity12872.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity12872.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12872.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity12872.addComponent(new TextShape())
entity12872.getComponent(TextShape).value = "sphere"
entity12872.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12872.getComponent(TextShape).width = 14.4
entity12872.getComponent(TextShape).height = 3.79186
entity12872.getComponent(TextShape).fontSize = 912

var entity12576 = new Entity("box (2)")
entity12576.setParent(entity12432)
entity12576.addComponent(new Transform({ position: new Vector3(2.105, 0, -1.064) }))
entity12576.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12576.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity12576.addComponent(new BoxShape())
entity12576.getComponent(BoxShape).withCollisions = true

var entity12400 = new Entity("Text")
entity12400.setParent(entity12576)
entity12400.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity12400.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12400.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity12400.addComponent(new TextShape())
entity12400.getComponent(TextShape).value = "cylinder"
entity12400.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12400.getComponent(TextShape).width = 16.2
entity12400.getComponent(TextShape).height = 3.79186
entity12400.getComponent(TextShape).fontSize = 912

var entity12802 = new Entity("box (3)")
entity12802.setParent(entity12432)
entity12802.addComponent(new Transform({ position: new Vector3(3.413, 0, -1.064) }))
entity12802.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12802.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity12802.addComponent(new BoxShape())
entity12802.getComponent(BoxShape).withCollisions = true

var entity12718 = new Entity("Text")
entity12718.setParent(entity12802)
entity12718.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity12718.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12718.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity12718.addComponent(new TextShape())
entity12718.getComponent(TextShape).value = "cone"
entity12718.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12718.getComponent(TextShape).width = 10.2
entity12718.getComponent(TextShape).height = 3.79186
entity12718.getComponent(TextShape).fontSize = 912

var entity12524 = new Entity("box (4)")
entity12524.setParent(entity12432)
entity12524.addComponent(new Transform({ position: new Vector3(4.701, 0, -1.064) }))
entity12524.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12524.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity12524.addComponent(new BoxShape())
entity12524.getComponent(BoxShape).withCollisions = true

var entity12546 = new Entity("Text")
entity12546.setParent(entity12524)
entity12546.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity12546.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12546.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity12546.addComponent(new TextShape())
entity12546.getComponent(TextShape).value = "plane"
entity12546.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12546.getComponent(TextShape).width = 11.4
entity12546.getComponent(TextShape).height = 3.79186
entity12546.getComponent(TextShape).fontSize = 912

var entity12678 = new Entity("box")
entity12678.setParent(entity12432)
entity12678.addComponent(new Transform({ position: new Vector3(-0.656, 0.423, 0) }))
entity12678.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12678.getComponent(Transform).scale.set(0.8517668, 0.8517668, 0.8517668)
entity12678.addComponent(new BoxShape())
entity12678.getComponent(BoxShape).withCollisions = true
var material11364 = new Material()
material11364.albedoColor = new Color3(1, 1, 1)
material11364.metallic = 0
material11364.roughness = 0.07999998
material11364.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/colormap.png")
entity12678.addComponent(material11364)

var entity12952 = new Entity("plane")
entity12952.setParent(entity12432)
entity12952.addComponent(new Transform({ position: new Vector3(4.826, 0.512, 0) }))
entity12952.getComponent(Transform).rotation.set(0, 0, -0.08550682, 0.9963376)
entity12952.getComponent(Transform).scale.set(0.7253101, 0.7253101, 0.72531)
entity12952.addComponent(new PlaneShape())
entity12952.getComponent(PlaneShape).withCollisions = true
entity12952.addComponent(material11364)

var entity12300 = new Entity("sphere")
entity12300.setParent(entity12432)
entity12300.addComponent(new Transform({ position: new Vector3(0.752, 0.469, 0) }))
entity12300.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12300.getComponent(Transform).scale.set(1, 1, 1)
entity12300.addComponent(new SphereShape())
entity12300.getComponent(SphereShape).withCollisions = true
entity12300.addComponent(material11364)

var entity12932 = new Entity("cylinder")
entity12932.setParent(entity12432)
entity12932.addComponent(new Transform({ position: new Vector3(2.148, 0.479, 0) }))
entity12932.getComponent(Transform).rotation.set(0.1208406, 0, 0, 0.992672)
entity12932.getComponent(Transform).scale.set(0.43202, 0.4320199, 0.4320199)
entity12932.addComponent(new CylinderShape())
entity12932.getComponent(CylinderShape).withCollisions = true
entity12932.addComponent(material11364)

var entity12324 = new Entity("cone")
entity12324.setParent(entity12432)
entity12324.addComponent(new Transform({ position: new Vector3(3.44, 0.646, 0) }))
entity12324.getComponent(Transform).rotation.set(-0.1093272, 0, 0, 0.9940059)
entity12324.getComponent(Transform).scale.set(0.5, 0.5, 0.5)
entity12324.addComponent(new ConeShape())
entity12324.getComponent(ConeShape).withCollisions = true
entity12324.addComponent(material11364)

var entity12566 = new Entity("box (5)")
entity12566.setParent(entity12432)
entity12566.addComponent(new Transform({ position: new Vector3(6.34, 0.48, 0) }))
entity12566.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12566.getComponent(Transform).scale.set(0.6975996, 0.6975996, 0.6975996)
entity12566.addComponent(new BoxShape())
entity12566.getComponent(BoxShape).withCollisions = true
var material11334 = new Material()
material11334.albedoColor = new Color3(1, 0.8428989, 0.06132078)
material11334.metallic = 1
material11334.roughness = 0.43
material11334.bumpTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/bump.jpg")
entity12566.addComponent(material11334)

var entity12892 = new Entity("box (6)")
entity12892.setParent(entity12432)
entity12892.addComponent(new Transform({ position: new Vector3(6.345, 0, -1.064) }))
entity12892.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12892.getComponent(Transform).scale.set(1.06, 0.14604, 0.14604)
entity12892.addComponent(new BoxShape())
entity12892.getComponent(BoxShape).withCollisions = true

var entity12248 = new Entity("Text")
entity12248.setParent(entity12892)
entity12248.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050002) }))
entity12248.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12248.getComponent(Transform).scale.set(0.04969757, 0.3369948, 0.1082157)
entity12248.addComponent(new TextShape())
entity12248.getComponent(TextShape).value = "special\ material"
entity12248.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12248.getComponent(TextShape).width = 32
entity12248.getComponent(TextShape).height = 3.791861
entity12248.getComponent(TextShape).fontSize = 912

var entity12232 = new Entity("Area1")
engine.addEntity(entity12232)
entity12232.addComponent(new Transform({ position: new Vector3(15.6, 0, 5) }))
entity12232.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12232.getComponent(Transform).scale.set(1, 1, 1)

var entity13048 = new Entity("box (5)")
entity13048.setParent(entity12232)
entity13048.addComponent(new Transform({ position: new Vector3(-2.091, 0.867, -0.725) }))
entity13048.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity13048.getComponent(Transform).scale.set(0.7059714, 0.14604, 0.14604)
entity13048.addComponent(new BoxShape())
entity13048.getComponent(BoxShape).withCollisions = true

var entity12460 = new Entity("Text")
entity12460.setParent(entity13048)
entity12460.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050002) }))
entity12460.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12460.getComponent(Transform).scale.set(0.07461976, 0.3369948, 0.1082158)
entity12460.addComponent(new TextShape())
entity12460.getComponent(TextShape).value = "gltf-model"
entity12460.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12460.getComponent(TextShape).width = 20.8
entity12460.getComponent(TextShape).height = 3.79186
entity12460.getComponent(TextShape).fontSize = 912

var entity12470 = new Entity("box (6)")
entity12470.setParent(entity12232)
entity12470.addComponent(new Transform({ position: new Vector3(-0.606, 1.8781, 1.71) }))
entity12470.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity12470.getComponent(Transform).scale.set(0.5407659, 0.14604, 0.14604)
entity12470.addComponent(new BoxShape())
entity12470.getComponent(BoxShape).withCollisions = true

var entity12708 = new Entity("Text")
entity12708.setParent(entity12470)
entity12708.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050003) }))
entity12708.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12708.getComponent(Transform).scale.set(0.0974161, 0.3369948, 0.1082158)
entity12708.addComponent(new TextShape())
entity12708.getComponent(TextShape).value = "video"
entity12708.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12708.getComponent(TextShape).width = 11.2
entity12708.getComponent(TextShape).height = 3.79186
entity12708.getComponent(TextShape).fontSize = 912

var entity12310 = new Entity("Gamer_Setup")
entity12310.setParent(entity12232)
entity12310.addComponent(new Transform({ position: new Vector3(-0.5608654, 1.0374, 1.317482) }))
entity12310.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity12310.getComponent(Transform).scale.set(0.1754544, 0.1754544, 0.1754544)

var entity12656 = new Entity("Cube_000")
entity12656.setParent(entity12310)
entity12656.addComponent(new Transform({ position: new Vector3(12.11426, 5.309812, -3.49059) }))
entity12656.getComponent(Transform).rotation.set(-0.6806849, -0.1914894, -0.1914894, 0.6806849)
entity12656.getComponent(Transform).scale.set(0.1367972, 0.1367972, 0.1367972)
entity12656.addComponent(new GLTFShape("./unity_assets/entity12656.gltf"))
entity12656.getComponent(Transform).rotation.set(-0.1914894, -0.680685, 0.6806848, -0.1914895)
var entity12922 = new Entity("Cube_001")
entity12922.setParent(entity12310)
entity12922.addComponent(new Transform({ position: new Vector3(0.2170952, -0.5116696, 0.5035708) }))
entity12922.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity12922.getComponent(Transform).scale.set(1, 1, 1)
entity12922.addComponent(new GLTFShape("./unity_assets/entity12922.gltf"))
entity12922.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity12782 = new Entity("Cube_002")
entity12782.setParent(entity12310)
entity12782.addComponent(new Transform({ position: new Vector3(0.1646543, 5.259673, -5.59996) }))
entity12782.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity12782.getComponent(Transform).scale.set(0.1243247, 0.1243247, 0.1243247)
entity12782.addComponent(new GLTFShape("./unity_assets/entity12782.gltf"))
entity12782.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity12492 = new Entity("Cube_005")
entity12492.setParent(entity12310)
entity12492.addComponent(new Transform({ position: new Vector3(10.1875, -0.1889177, -11.27131) }))
entity12492.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity12492.getComponent(Transform).scale.set(2.081236, 2.081236, 2.081236)
entity12492.addComponent(new GLTFShape("./unity_assets/entity12492.gltf"))
entity12492.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity12422 = new Entity("Cube_011")
entity12422.setParent(entity12310)
entity12422.addComponent(new Transform({ position: new Vector3(-7.849312, 8.45981, -4.598763) }))
entity12422.getComponent(Transform).rotation.set(0.2357263, 0.6666582, 0.6666582, -0.2357263)
entity12422.getComponent(Transform).scale.set(2.751107, 2.751107, 2.751106)
entity12422.addComponent(new GLTFShape("./unity_assets/entity12422.gltf"))
entity12422.getComponent(Transform).rotation.set(0.6666581, 0.2357263, -0.2357263, 0.6666583)
var entity12278 = new Entity("Cube_012")
entity12278.setParent(entity12310)
entity12278.addComponent(new Transform({ position: new Vector3(-7.849312, 8.45981, -4.598763) }))
entity12278.getComponent(Transform).rotation.set(0.2357263, 0.6666582, 0.6666582, -0.2357263)
entity12278.getComponent(Transform).scale.set(2.751107, 2.751107, 2.751106)
entity12278.addComponent(new GLTFShape("./unity_assets/entity12278.gltf"))
entity12278.getComponent(Transform).rotation.set(0.6666581, 0.2357263, -0.2357263, 0.6666583)
var entity12368 = new Entity("Cube_013")
entity12368.setParent(entity12310)
entity12368.addComponent(new Transform({ position: new Vector3(12.11426, 5.309812, -3.49059) }))
entity12368.getComponent(Transform).rotation.set(-0.6806849, -0.1914894, -0.1914894, 0.6806849)
entity12368.getComponent(Transform).scale.set(0.1367972, 0.1367972, 0.1367972)
entity12368.addComponent(new GLTFShape("./unity_assets/entity12368.gltf"))
entity12368.getComponent(Transform).rotation.set(-0.1914894, -0.680685, 0.6806848, -0.1914895)
var entity12668 = new Entity("Cube_019")
entity12668.setParent(entity12310)
entity12668.addComponent(new Transform({ position: new Vector3(0.1646543, 5.259673, -5.59996) }))
entity12668.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity12668.getComponent(Transform).scale.set(0.1243247, 0.1243247, 0.1243247)
entity12668.addComponent(new GLTFShape("./unity_assets/entity12668.gltf"))
entity12668.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity12556 = new Entity("box")
entity12556.setParent(entity12232)
entity12556.addComponent(new Transform({ position: new Vector3(-0.7281885, 0.1298423, -2.920463) }))
entity12556.getComponent(Transform).rotation.set(-0.1747413, 0, 0, 0.9846144)
entity12556.getComponent(Transform).scale.set(2.489491, 0.4594609, 2.993707)
entity12556.addComponent(new BoxShape())
entity12556.getComponent(BoxShape).withCollisions = true
var material12092 = new Material()
material12092.albedoColor = new Color3(0.8, 0.8, 0.8)
material12092.metallic = 0
material12092.roughness = 1
material12092.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Gamer/Floor.jpg")
entity12556.addComponent(material12092)

var entity12972 = new Entity("cylinder")
entity12972.setParent(entity12232)
entity12972.addComponent(new Transform({ position: new Vector3(-0.6813383, -3.212592, 0.7820497) }))
entity12972.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12972.getComponent(Transform).scale.set(2.712223, 4.079235, 2.712223)
entity12972.addComponent(new CylinderShape())
entity12972.getComponent(CylinderShape).withCollisions = true
entity12972.addComponent(material12092)

var entity12992 = new Entity("video")
entity12992.setParent(entity12232)
entity12992.addComponent(new Transform({ position: new Vector3(-0.5682278, 2.449601, 2.158779) }))
entity12992.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12992.getComponent(Transform).scale.set(0.6625971, 0.6625971, 0.6625971)

var entity12586 = new Entity("sound(custom node)")
entity12586.setParent(entity12232)
entity12586.addComponent(new Transform({ position: new Vector3(-0.06900024, 2.568, 2.109) }))
entity12586.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12586.getComponent(Transform).scale.set(1, 1, 1)

var entity13078 = new Entity("credit")
entity13078.setParent(entity12232)
entity13078.addComponent(new Transform({ position: new Vector3(-0.5459995, 1.287, 2.516) }))
entity13078.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity13078.getComponent(Transform).scale.set(0.05583001, 0.05583001, 0.05583001)
entity13078.addComponent(new TextShape())
entity13078.getComponent(TextShape).value = "https://sketchfab\.com/models/691\n45aa6647a42849487b6c3404f5075"
entity13078.getComponent(TextShape).color = new Color3(0, 0, 0)
entity13078.getComponent(TextShape).width = 32
entity13078.getComponent(TextShape).height = 10.88203
entity13078.getComponent(TextShape).fontSize = 912

var entity13022 = new Entity("box (7)")
entity13022.setParent(entity12232)
entity13022.addComponent(new Transform({ position: new Vector3(3.961, 0.001, -4.449) }))
entity13022.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity13022.getComponent(Transform).scale.set(0.9, 0.14604, 0.14604)
entity13022.addComponent(new BoxShape())
entity13022.getComponent(BoxShape).withCollisions = true

var entity12772 = new Entity("Text")
entity12772.setParent(entity13022)
entity12772.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050003) }))
entity12772.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity12772.getComponent(Transform).scale.set(0.05853257, 0.3369948, 0.1082158)
entity12772.addComponent(new TextShape())
entity12772.getComponent(TextShape).value = "out\ of\ range"
entity12772.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity12772.getComponent(TextShape).width = 25.4
entity12772.getComponent(TextShape).height = 3.79186
entity12772.getComponent(TextShape).fontSize = 912

var entity12514 = new Entity("box")
entity12514.setParent(entity12232)
entity12514.addComponent(new Transform({ position: new Vector3(5.075, 0.968467, -5.077) }))
entity12514.getComponent(Transform).rotation.set(-0.3696432, 0.09904541, -0.2391173, 0.8923995)
entity12514.getComponent(Transform).scale.set(1, 1, 1)
entity12514.addComponent(new BoxShape())
entity12514.getComponent(BoxShape).withCollisions = true

var entity13014 = new Entity("AudioSource")
engine.addEntity(entity13014)
entity13014.addComponent(new Transform({ position: new Vector3(7.050802, 0.2895149, 2.484241) }))
entity13014.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity13014.getComponent(Transform).scale.set(1, 1, 1)

var audioSource = new AudioSource(new AudioClip('unity_assets/Assets/Decentraland/Sample-01/bgm.mp3'))
var playAudioSource13016 = () => {
  entity13014.addComponent(audioSource)
  audioSource.playing = true
  audioSource.loop = false
  audioSource.volume = 1
  audioSource.pitch = 1
}

export class AutoPlayUnityAudio implements ISystem {
  activate() {
    playAudioSource13016()
  }
}
engine.addSystem(new AutoPlayUnityAudio())

