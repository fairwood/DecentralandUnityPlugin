var entity32738 = new Entity("Main Camera")
engine.addEntity(entity32738)
entity32738.addComponent(new Transform({ position: new Vector3(0, 1, -10) }))
entity32738.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32738.getComponent(Transform).scale.set(1, 1, 1)

var entity32558 = new Entity("Directional Light")
engine.addEntity(entity32558)
entity32558.addComponent(new Transform({ position: new Vector3(1.341, 6.197, -2.323) }))
entity32558.getComponent(Transform).rotation.set(0.4082179, -0.2345697, 0.1093816, 0.8754261)
entity32558.getComponent(Transform).scale.set(1, 1, 1)

var entity33322 = new Entity("Frame")
engine.addEntity(entity33322)
entity33322.addComponent(new Transform({ position: new Vector3(15, 0, 5) }))
entity33322.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33322.getComponent(Transform).scale.set(1, 1, 1)

var entity32900 = new Entity("plane")
entity32900.setParent(entity33322)
entity32900.addComponent(new Transform({ position: new Vector3(-5, 3.68928, -4.97) }))
entity32900.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32900.getComponent(Transform).scale.set(19.94, 0.8, 1)
entity32900.addComponent(new PlaneShape())
entity32900.getComponent(PlaneShape).withCollisions = true

var entity32922 = new Entity("plane (1)")
entity32922.setParent(entity33322)
entity32922.addComponent(new Transform({ position: new Vector3(-5, 3.68928, 4.97) }))
entity32922.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32922.getComponent(Transform).scale.set(19.94, 0.8, 1)
entity32922.addComponent(new PlaneShape())
entity32922.getComponent(PlaneShape).withCollisions = true

var entity32648 = new Entity("plane (2)")
entity32648.setParent(entity33322)
entity32648.addComponent(new Transform({ position: new Vector3(-14.97, 3.68928, 0) }))
entity32648.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity32648.getComponent(Transform).scale.set(9.970012, 0.8, 1)
entity32648.addComponent(new PlaneShape())
entity32648.getComponent(PlaneShape).withCollisions = true

var entity33338 = new Entity("plane (3)")
entity33338.setParent(entity33322)
entity33338.addComponent(new Transform({ position: new Vector3(4.97, 3.68928, 0) }))
entity33338.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity33338.getComponent(Transform).scale.set(9.970012, 0.8, 1)
entity33338.addComponent(new PlaneShape())
entity33338.getComponent(PlaneShape).withCollisions = true

var entity32680 = new Entity("column")
entity32680.setParent(entity33322)
entity32680.addComponent(new Transform({ position: new Vector3(-14.958, 2, -4.95) }))
entity32680.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32680.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity32680.addComponent(new BoxShape())
entity32680.getComponent(BoxShape).withCollisions = true

var entity33388 = new Entity("column (1)")
entity33388.setParent(entity33322)
entity33388.addComponent(new Transform({ position: new Vector3(-4.956539, 2, -4.95) }))
entity33388.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33388.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity33388.addComponent(new BoxShape())
entity33388.getComponent(BoxShape).withCollisions = true

var entity33170 = new Entity("column (2)")
entity33170.setParent(entity33322)
entity33170.addComponent(new Transform({ position: new Vector3(4.935, 2, -4.95) }))
entity33170.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33170.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity33170.addComponent(new BoxShape())
entity33170.getComponent(BoxShape).withCollisions = true

var entity32576 = new Entity("column (4)")
entity32576.setParent(entity33322)
entity32576.addComponent(new Transform({ position: new Vector3(-14.958, 2, 4.952) }))
entity32576.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32576.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity32576.addComponent(new BoxShape())
entity32576.getComponent(BoxShape).withCollisions = true

var entity33132 = new Entity("column (5)")
entity33132.setParent(entity33322)
entity33132.addComponent(new Transform({ position: new Vector3(-4.956539, 2, 4.952) }))
entity33132.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33132.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity33132.addComponent(new BoxShape())
entity33132.getComponent(BoxShape).withCollisions = true

var entity33378 = new Entity("column (6)")
entity33378.setParent(entity33322)
entity33378.addComponent(new Transform({ position: new Vector3(4.935, 2, 4.952) }))
entity33378.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33378.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity33378.addComponent(new BoxShape())
entity33378.getComponent(BoxShape).withCollisions = true

var entity32978 = new Entity("plane (4)")
entity32978.setParent(entity33322)
entity32978.addComponent(new Transform({ position: new Vector3(-5, 3.5, -4.98) }))
entity32978.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32978.getComponent(Transform).scale.set(19.94, 0.04, 1)
entity32978.addComponent(new PlaneShape())
entity32978.getComponent(PlaneShape).withCollisions = true
var material3306 = new Material()
material3306.albedoColor = new Color3(0, 0, 0)
material3306.metallic = 0
material3306.roughness = 0.5
material3306.emissiveColor = new Color3(0.04313726, 0, 0.1872549)
entity32978.addComponent(material3306)

var entity32638 = new Entity("plane (5)")
entity32638.setParent(entity33322)
entity32638.addComponent(new Transform({ position: new Vector3(-5, 3.5, 4.98) }))
entity32638.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32638.getComponent(Transform).scale.set(19.94, 0.04, 1)
entity32638.addComponent(new PlaneShape())
entity32638.getComponent(PlaneShape).withCollisions = true
entity32638.addComponent(material3306)

var entity33312 = new Entity("plane (6)")
entity33312.setParent(entity33322)
entity33312.addComponent(new Transform({ position: new Vector3(-14.98, 3.5, 0) }))
entity33312.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity33312.getComponent(Transform).scale.set(9.970014, 0.04, 1)
entity33312.addComponent(new PlaneShape())
entity33312.getComponent(PlaneShape).withCollisions = true
entity33312.addComponent(material3306)

var entity33398 = new Entity("plane (7)")
entity33398.setParent(entity33322)
entity33398.addComponent(new Transform({ position: new Vector3(4.98, 3.5, 0) }))
entity33398.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity33398.getComponent(Transform).scale.set(9.970014, 0.04, 1)
entity33398.addComponent(new PlaneShape())
entity33398.getComponent(PlaneShape).withCollisions = true
entity33398.addComponent(material3306)

var entity32932 = new Entity("Title")
entity32932.setParent(entity33322)
entity32932.addComponent(new Transform({ position: new Vector3(-10, 3.755, -4.999) }))
entity32932.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32932.getComponent(Transform).scale.set(0.1846309, 0.1846309, 0.1846309)
entity32932.addComponent(new TextShape())
entity32932.getComponent(TextShape).value = "DCL\ UNITY\ EXPORTER"
entity32932.getComponent(TextShape).color = new Color3(0.172549, 0, 0.7490196)
entity32932.getComponent(TextShape).width = 32
entity32932.getComponent(TextShape).height = 5.3625
entity32932.getComponent(TextShape).fontSize = 912

var entity32770 = new Entity("Title (1)")
entity32770.setParent(entity33322)
entity32770.addComponent(new Transform({ position: new Vector3(0, 3.755, -4.999) }))
entity32770.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32770.getComponent(Transform).scale.set(0.1846309, 0.1846309, 0.1846309)
entity32770.addComponent(new TextShape())
entity32770.getComponent(TextShape).value = "DCL\ UNITY\ EXPORTER"
entity32770.getComponent(TextShape).color = new Color3(0.172549, 0, 0.7490196)
entity32770.getComponent(TextShape).width = 32
entity32770.getComponent(TextShape).height = 5.3625
entity32770.getComponent(TextShape).fontSize = 912

var entity33270 = new Entity("roof")
entity33270.setParent(entity33322)
entity33270.addComponent(new Transform({ position: new Vector3(-5, 4.1, 0) }))
entity33270.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity33270.getComponent(Transform).scale.set(19.97, 9.98, 1)
entity33270.addComponent(new PlaneShape())
entity33270.getComponent(PlaneShape).withCollisions = true

var entity32894 = new Entity("Front desk")
engine.addEntity(entity32894)
entity32894.addComponent(new Transform({ position: new Vector3(7.106, 0.5, 0.343) }))
entity32894.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32894.getComponent(Transform).scale.set(1, 1, 1)

var entity33112 = new Entity("plane")
entity33112.setParent(entity32894)
entity33112.addComponent(new Transform({ position: new Vector3(-1, 0.06, -0.3309999) }))
entity33112.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33112.getComponent(Transform).scale.set(0.5617885, 0.5617885, 0.5617885)
entity33112.addComponent(new PlaneShape())
entity33112.getComponent(PlaneShape).withCollisions = true
var material3244 = new Material()
material3244.albedoColor = new Color3(0, 0, 0)
material3244.metallic = 0
material3244.roughness = 0.5
material3244.emissiveColor = new Color3(1, 1, 1)
material3244.emissiveTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/fairwood_logo.jpg")
entity33112.addComponent(material3244)

var entity33020 = new Entity("Table")
entity33020.setParent(entity32894)
entity33020.addComponent(new Transform({ position: new Vector3(0, 0, 0) }))
entity33020.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33020.getComponent(Transform).scale.set(3.0906, 1, 0.6410449)
entity33020.addComponent(new BoxShape())
entity33020.getComponent(BoxShape).withCollisions = true
var material3072 = new Material()
material3072.albedoColor = new Color3(0.8962264, 0.8938915, 0.875089)
material3072.metallic = 0
material3072.roughness = 0.11
entity33020.addComponent(material3072)

var entity32794 = new Entity("plane (8)")
entity32794.setParent(entity33020)
entity32794.addComponent(new Transform({ position: new Vector3(0.001, -0.345, -0.5038648) }))
entity32794.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32794.getComponent(Transform).scale.set(1, 0.04, 1.559953)
entity32794.addComponent(new PlaneShape())
entity32794.getComponent(PlaneShape).withCollisions = true
entity32794.addComponent(material3306)

var entity33230 = new Entity("Text")
entity33230.setParent(entity32894)
entity33230.addComponent(new Transform({ position: new Vector3(0.355, 0.04500002, -0.342) }))
entity33230.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33230.getComponent(Transform).scale.set(0.133473, 0.133473, 0.133473)
entity33230.addComponent(new TextShape())
entity33230.getComponent(TextShape).value = "FAIRWOOD"
entity33230.getComponent(TextShape).color = new Color3(0, 0.4627451, 0.09803922)
entity33230.getComponent(TextShape).width = 26.6
entity33230.getComponent(TextShape).height = 5.3625
entity33230.getComponent(TextShape).fontSize = 912

var entity32830 = new Entity("Map Board")
engine.addEntity(entity32830)
entity32830.addComponent(new Transform({ position: new Vector3(1.59, 0, 1.016) }))
entity32830.getComponent(Transform).rotation.set(0, -0.2588186, 0, 0.965926)
entity32830.getComponent(Transform).scale.set(1.3902, 1.3902, 1.3902)

var entity33142 = new Entity("plane")
entity33142.setParent(entity32830)
entity33142.addComponent(new Transform({ position: new Vector3(0, 1.065, 0) }))
entity33142.getComponent(Transform).rotation.set(0.05113563, 0, 0, 0.9986918)
entity33142.getComponent(Transform).scale.set(1, 1, 1)
entity33142.addComponent(new PlaneShape())
entity33142.getComponent(PlaneShape).withCollisions = true
var material3158 = new Material()
material3158.albedoColor = new Color3(1, 1, 1)
material3158.metallic = 0
material3158.roughness = 0.5
material3158.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/dcl_map.png")
entity33142.addComponent(material3158)

var entity33250 = new Entity("column (8)")
entity33250.setParent(entity32830)
entity33250.addComponent(new Transform({ position: new Vector3(-0.25, 0.4, -0.03399992) }))
entity33250.getComponent(Transform).rotation.set(0.03848108, 0.00307059, -0.0794827, 0.9960885)
entity33250.getComponent(Transform).scale.set(0.04000001, 0.8256255, 0.03999999)
entity33250.addComponent(new BoxShape())
entity33250.getComponent(BoxShape).withCollisions = true

var entity33292 = new Entity("column (9)")
entity33292.setParent(entity32830)
entity33292.addComponent(new Transform({ position: new Vector3(0.25, 0.4, -0.034) }))
entity33292.getComponent(Transform).rotation.set(0.03848109, -0.003070428, 0.07947849, 0.9960889)
entity33292.getComponent(Transform).scale.set(0.04000001, 0.8256252, 0.03999999)
entity33292.addComponent(new BoxShape())
entity33292.getComponent(BoxShape).withCollisions = true

var entity32910 = new Entity("column (10)")
entity32910.setParent(entity32830)
entity32910.addComponent(new Transform({ position: new Vector3(0, 0.392, 0.205) }))
entity32910.getComponent(Transform).rotation.set(-0.2456335, 0, 0, 0.9693628)
entity32910.getComponent(Transform).scale.set(0.04, 0.8888682, 0.04)
entity32910.addComponent(new BoxShape())
entity32910.getComponent(BoxShape).withCollisions = true

var entity32728 = new Entity("column (11)")
entity32728.setParent(entity32830)
entity32728.addComponent(new Transform({ position: new Vector3(0, 0.788, -0.004) }))
entity32728.getComponent(Transform).rotation.set(0, 0, 0.7071058, 0.7071078)
entity32728.getComponent(Transform).scale.set(0.04000001, 0.6386578, 0.03999999)
entity32728.addComponent(new BoxShape())
entity32728.getComponent(BoxShape).withCollisions = true

var entity32722 = new Entity("Area0")
engine.addEntity(entity32722)
entity32722.addComponent(new Transform({ position: new Vector3(3.38, 0, 5) }))
entity32722.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32722.getComponent(Transform).scale.set(1, 1, 1)

var entity32824 = new Entity("Frame")
entity32824.setParent(entity32722)
entity32824.addComponent(new Transform({ position: new Vector3(1.93, 0, 0) }))
entity32824.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32824.getComponent(Transform).scale.set(1, 1, 1)

var entity33050 = new Entity("cylinder")
entity33050.setParent(entity32824)
entity33050.addComponent(new Transform({ position: new Vector3(-3.43, 0.4, -1.532) }))
entity33050.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33050.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity33050.addComponent(new CylinderShape())
entity33050.getComponent(CylinderShape).withCollisions = true
var material3360 = new Material()
material3360.albedoColor = new Color3(0.3962264, 0.307827, 0.07662868)
material3360.metallic = 1
material3360.roughness = 0.331
entity33050.addComponent(material3360)

var entity32546 = new Entity("cylinder (1)")
entity32546.setParent(entity32824)
entity32546.addComponent(new Transform({ position: new Vector3(5.57, 0.4, -1.532) }))
entity32546.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32546.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity32546.addComponent(new CylinderShape())
entity32546.getComponent(CylinderShape).withCollisions = true
entity32546.addComponent(material3360)

var entity33348 = new Entity("cylinder (2)")
entity33348.setParent(entity32824)
entity33348.addComponent(new Transform({ position: new Vector3(-3.43, 0.4, 0.89) }))
entity33348.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33348.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity33348.addComponent(new CylinderShape())
entity33348.getComponent(CylinderShape).withCollisions = true
entity33348.addComponent(material3360)

var entity32604 = new Entity("cylinder (3)")
entity32604.setParent(entity32824)
entity32604.addComponent(new Transform({ position: new Vector3(5.57, 0.4, 0.89) }))
entity32604.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32604.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity32604.addComponent(new CylinderShape())
entity32604.getComponent(CylinderShape).withCollisions = true
entity32604.addComponent(material3360)

var entity32628 = new Entity("Tape")
entity32628.setParent(entity32824)
entity32628.addComponent(new Transform({ position: new Vector3(1.07, 0.65, -1.532) }))
entity32628.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32628.getComponent(Transform).scale.set(8.986068, 0.08110655, 1)
entity32628.addComponent(new PlaneShape())
var material3304 = new Material()
material3304.albedoColor = new Color3(0.3701339, 0.3436276, 0.6226415)
material3304.metallic = 0
material3304.roughness = 0.5
material3304.hasAlpha = true
material3304.alpha = 0.2784314
entity32628.addComponent(material3304)

var entity33040 = new Entity("Title (4)")
entity33040.setParent(entity32628)
entity33040.addComponent(new Transform({ position: new Vector3(-0.3521428, 0, -0.004700065) }))
entity33040.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33040.getComponent(Transform).scale.set(0.004800823, 0.4143409, 0.03360576)
entity33040.addComponent(new TextShape())
entity33040.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity33040.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity33040.getComponent(TextShape).width = 32
entity33040.getComponent(TextShape).height = 5.3625
entity33040.getComponent(TextShape).fontSize = 912

var entity32884 = new Entity("Title (5)")
entity32884.setParent(entity32628)
entity32884.addComponent(new Transform({ position: new Vector3(-0.1297143, 0, -0.004700065) }))
entity32884.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32884.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity32884.addComponent(new TextShape())
entity32884.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity32884.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity32884.getComponent(TextShape).width = 32
entity32884.getComponent(TextShape).height = 5.3625
entity32884.getComponent(TextShape).fontSize = 912

var entity33030 = new Entity("Title (6)")
entity33030.setParent(entity32628)
entity33030.addComponent(new Transform({ position: new Vector3(0.08285712, 0, -0.004700065) }))
entity33030.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33030.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity33030.addComponent(new TextShape())
entity33030.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity33030.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity33030.getComponent(TextShape).width = 32
entity33030.getComponent(TextShape).height = 5.3625
entity33030.getComponent(TextShape).fontSize = 912

var entity32700 = new Entity("Title (7)")
entity32700.setParent(entity32628)
entity32700.addComponent(new Transform({ position: new Vector3(0.282, 0, -0.004700065) }))
entity32700.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32700.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity32700.addComponent(new TextShape())
entity32700.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity32700.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity32700.getComponent(TextShape).width = 32
entity32700.getComponent(TextShape).height = 5.3625
entity32700.getComponent(TextShape).fontSize = 912

var entity33102 = new Entity("Tape (1)")
entity33102.setParent(entity32824)
entity33102.addComponent(new Transform({ position: new Vector3(1.07, 0.65, 0.89) }))
entity33102.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity33102.getComponent(Transform).scale.set(8.986068, 0.08111, 1)
entity33102.addComponent(new PlaneShape())
entity33102.addComponent(material3304)

var entity33190 = new Entity("Tape (2)")
entity33190.setParent(entity32824)
entity33190.addComponent(new Transform({ position: new Vector3(-3.427, 0.65, -0.323) }))
entity33190.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity33190.getComponent(Transform).scale.set(2.389797, 0.08111, 1)
entity33190.addComponent(new PlaneShape())
entity33190.addComponent(material3304)

var entity33368 = new Entity("Tape (3)")
entity33368.setParent(entity32824)
entity33368.addComponent(new Transform({ position: new Vector3(5.572, 0.65, -0.323) }))
entity33368.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity33368.getComponent(Transform).scale.set(2.389802, 0.08111, 1)
entity33368.addComponent(new PlaneShape())
entity33368.addComponent(material3304)

var entity32988 = new Entity("box")
entity32988.setParent(entity32722)
entity32988.addComponent(new Transform({ position: new Vector3(-0.661, 0, -1.064) }))
entity32988.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity32988.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity32988.addComponent(new BoxShape())
entity32988.getComponent(BoxShape).withCollisions = true

var entity33080 = new Entity("Text")
entity33080.setParent(entity32988)
entity33080.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity33080.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33080.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity33080.addComponent(new TextShape())
entity33080.getComponent(TextShape).value = "box"
entity33080.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity33080.getComponent(TextShape).width = 7.6
entity33080.getComponent(TextShape).height = 3.79186
entity33080.getComponent(TextShape).fontSize = 912

var entity33122 = new Entity("box (1)")
entity33122.setParent(entity32722)
entity33122.addComponent(new Transform({ position: new Vector3(0.689, 0, -1.064) }))
entity33122.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity33122.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity33122.addComponent(new BoxShape())
entity33122.getComponent(BoxShape).withCollisions = true

var entity33160 = new Entity("Text")
entity33160.setParent(entity33122)
entity33160.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity33160.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33160.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity33160.addComponent(new TextShape())
entity33160.getComponent(TextShape).value = "sphere"
entity33160.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity33160.getComponent(TextShape).width = 14.4
entity33160.getComponent(TextShape).height = 3.79186
entity33160.getComponent(TextShape).fontSize = 912

var entity32866 = new Entity("box (2)")
entity32866.setParent(entity32722)
entity32866.addComponent(new Transform({ position: new Vector3(2.105, 0, -1.064) }))
entity32866.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity32866.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity32866.addComponent(new BoxShape())
entity32866.getComponent(BoxShape).withCollisions = true

var entity32690 = new Entity("Text")
entity32690.setParent(entity32866)
entity32690.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity32690.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32690.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity32690.addComponent(new TextShape())
entity32690.getComponent(TextShape).value = "cylinder"
entity32690.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity32690.getComponent(TextShape).width = 16.2
entity32690.getComponent(TextShape).height = 3.79186
entity32690.getComponent(TextShape).fontSize = 912

var entity33090 = new Entity("box (3)")
entity33090.setParent(entity32722)
entity33090.addComponent(new Transform({ position: new Vector3(3.413, 0, -1.064) }))
entity33090.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity33090.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity33090.addComponent(new BoxShape())
entity33090.getComponent(BoxShape).withCollisions = true

var entity33008 = new Entity("Text")
entity33008.setParent(entity33090)
entity33008.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity33008.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33008.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity33008.addComponent(new TextShape())
entity33008.getComponent(TextShape).value = "cone"
entity33008.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity33008.getComponent(TextShape).width = 10.2
entity33008.getComponent(TextShape).height = 3.79186
entity33008.getComponent(TextShape).fontSize = 912

var entity32814 = new Entity("box (4)")
entity32814.setParent(entity32722)
entity32814.addComponent(new Transform({ position: new Vector3(4.701, 0, -1.064) }))
entity32814.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity32814.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity32814.addComponent(new BoxShape())
entity32814.getComponent(BoxShape).withCollisions = true

var entity32836 = new Entity("Text")
entity32836.setParent(entity32814)
entity32836.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity32836.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32836.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity32836.addComponent(new TextShape())
entity32836.getComponent(TextShape).value = "plane"
entity32836.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity32836.getComponent(TextShape).width = 11.4
entity32836.getComponent(TextShape).height = 3.79186
entity32836.getComponent(TextShape).fontSize = 912

var entity32968 = new Entity("box")
entity32968.setParent(entity32722)
entity32968.addComponent(new Transform({ position: new Vector3(-0.656, 0.423, 0) }))
entity32968.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32968.getComponent(Transform).scale.set(0.8517668, 0.8517668, 0.8517668)
entity32968.addComponent(new BoxShape())
entity32968.getComponent(BoxShape).withCollisions = true
var material2776 = new Material()
material2776.albedoColor = new Color3(1, 1, 1)
material2776.metallic = 0
material2776.roughness = 0.07999998
material2776.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/colormap.png")
entity32968.addComponent(material2776)

var entity33240 = new Entity("plane")
entity33240.setParent(entity32722)
entity33240.addComponent(new Transform({ position: new Vector3(4.826, 0.512, 0) }))
entity33240.getComponent(Transform).rotation.set(0, 0, -0.08550682, 0.9963376)
entity33240.getComponent(Transform).scale.set(0.7253101, 0.7253101, 0.72531)
entity33240.addComponent(new PlaneShape())
entity33240.getComponent(PlaneShape).withCollisions = true
entity33240.addComponent(material2776)

var entity32590 = new Entity("sphere")
entity32590.setParent(entity32722)
entity32590.addComponent(new Transform({ position: new Vector3(0.752, 0.469, 0) }))
entity32590.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32590.getComponent(Transform).scale.set(1, 1, 1)
entity32590.addComponent(new SphereShape())
entity32590.getComponent(SphereShape).withCollisions = true
entity32590.addComponent(material2776)

var entity33220 = new Entity("cylinder")
entity33220.setParent(entity32722)
entity33220.addComponent(new Transform({ position: new Vector3(2.148, 0.479, 0) }))
entity33220.getComponent(Transform).rotation.set(0.1208406, 0, 0, 0.992672)
entity33220.getComponent(Transform).scale.set(0.43202, 0.4320199, 0.4320199)
entity33220.addComponent(new CylinderShape())
entity33220.getComponent(CylinderShape).withCollisions = true
entity33220.addComponent(material2776)

var entity32614 = new Entity("cone")
entity32614.setParent(entity32722)
entity32614.addComponent(new Transform({ position: new Vector3(3.44, 0.646, 0) }))
entity32614.getComponent(Transform).rotation.set(-0.1093272, 0, 0, 0.9940059)
entity32614.getComponent(Transform).scale.set(0.5, 0.5, 0.5)
entity32614.addComponent(new ConeShape())
entity32614.getComponent(ConeShape).withCollisions = true
entity32614.addComponent(material2776)

var entity32856 = new Entity("box (5)")
entity32856.setParent(entity32722)
entity32856.addComponent(new Transform({ position: new Vector3(6.34, 0.48, 0) }))
entity32856.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32856.getComponent(Transform).scale.set(0.6975996, 0.6975996, 0.6975996)
entity32856.addComponent(new BoxShape())
entity32856.getComponent(BoxShape).withCollisions = true
var material2748 = new Material()
material2748.albedoColor = new Color3(1, 0.8428989, 0.06132078)
material2748.metallic = 1
material2748.roughness = 0.43
material2748.bumpTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/bump.jpg")
entity32856.addComponent(material2748)

var entity33180 = new Entity("box (6)")
entity33180.setParent(entity32722)
entity33180.addComponent(new Transform({ position: new Vector3(6.345, 0, -1.064) }))
entity33180.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity33180.getComponent(Transform).scale.set(1.06, 0.14604, 0.14604)
entity33180.addComponent(new BoxShape())
entity33180.getComponent(BoxShape).withCollisions = true

var entity32536 = new Entity("Text")
entity32536.setParent(entity33180)
entity32536.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050002) }))
entity32536.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32536.getComponent(Transform).scale.set(0.04969757, 0.3369948, 0.1082157)
entity32536.addComponent(new TextShape())
entity32536.getComponent(TextShape).value = "special\ material"
entity32536.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity32536.getComponent(TextShape).width = 32
entity32536.getComponent(TextShape).height = 3.791861
entity32536.getComponent(TextShape).fontSize = 912

var entity32520 = new Entity("Area1")
engine.addEntity(entity32520)
entity32520.addComponent(new Transform({ position: new Vector3(15.6, 0, 5) }))
entity32520.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32520.getComponent(Transform).scale.set(1, 1, 1)

var entity33328 = new Entity("box (5)")
entity33328.setParent(entity32520)
entity33328.addComponent(new Transform({ position: new Vector3(-2.091, 0.867, -0.725) }))
entity33328.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity33328.getComponent(Transform).scale.set(0.7059714, 0.14604, 0.14604)
entity33328.addComponent(new BoxShape())
entity33328.getComponent(BoxShape).withCollisions = true

var entity32750 = new Entity("Text")
entity32750.setParent(entity33328)
entity32750.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050002) }))
entity32750.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32750.getComponent(Transform).scale.set(0.07461976, 0.3369948, 0.1082158)
entity32750.addComponent(new TextShape())
entity32750.getComponent(TextShape).value = "gltf-model"
entity32750.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity32750.getComponent(TextShape).width = 20.8
entity32750.getComponent(TextShape).height = 3.79186
entity32750.getComponent(TextShape).fontSize = 912

var entity32760 = new Entity("box (6)")
entity32760.setParent(entity32520)
entity32760.addComponent(new Transform({ position: new Vector3(-0.606, 1.8781, 1.71) }))
entity32760.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity32760.getComponent(Transform).scale.set(0.5407659, 0.14604, 0.14604)
entity32760.addComponent(new BoxShape())
entity32760.getComponent(BoxShape).withCollisions = true

var entity32998 = new Entity("Text")
entity32998.setParent(entity32760)
entity32998.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050003) }))
entity32998.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32998.getComponent(Transform).scale.set(0.0974161, 0.3369948, 0.1082158)
entity32998.addComponent(new TextShape())
entity32998.getComponent(TextShape).value = "video"
entity32998.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity32998.getComponent(TextShape).width = 11.2
entity32998.getComponent(TextShape).height = 3.79186
entity32998.getComponent(TextShape).fontSize = 912

var entity32600 = new Entity("Gamer_Setup")
entity32600.setParent(entity32520)
entity32600.addComponent(new Transform({ position: new Vector3(-0.5608654, 1.0374, 1.317482) }))
entity32600.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity32600.getComponent(Transform).scale.set(0.1754544, 0.1754544, 0.1754544)

var entity32946 = new Entity("Cube_000")
entity32946.setParent(entity32600)
entity32946.addComponent(new Transform({ position: new Vector3(12.11426, 5.309812, -3.49059) }))
entity32946.getComponent(Transform).rotation.set(-0.6806849, -0.1914894, -0.1914894, 0.6806849)
entity32946.getComponent(Transform).scale.set(0.1367972, 0.1367972, 0.1367972)
entity32946.addComponent(new GLTFShape("./unity_assets/entity32946.gltf"))
entity32946.getComponent(Transform).rotation.set(-0.1914894, -0.680685, 0.6806848, -0.1914895)
var entity33210 = new Entity("Cube_001")
entity33210.setParent(entity32600)
entity33210.addComponent(new Transform({ position: new Vector3(0.2170952, -0.5116696, 0.5035708) }))
entity33210.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity33210.getComponent(Transform).scale.set(1, 1, 1)
entity33210.addComponent(new GLTFShape("./unity_assets/entity33210.gltf"))
entity33210.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity33070 = new Entity("Cube_002")
entity33070.setParent(entity32600)
entity33070.addComponent(new Transform({ position: new Vector3(0.1646543, 5.259673, -5.59996) }))
entity33070.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity33070.getComponent(Transform).scale.set(0.1243247, 0.1243247, 0.1243247)
entity33070.addComponent(new GLTFShape("./unity_assets/entity33070.gltf"))
entity33070.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity32782 = new Entity("Cube_005")
entity32782.setParent(entity32600)
entity32782.addComponent(new Transform({ position: new Vector3(10.1875, -0.1889177, -11.27131) }))
entity32782.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity32782.getComponent(Transform).scale.set(2.081236, 2.081236, 2.081236)
entity32782.addComponent(new GLTFShape("./unity_assets/entity32782.gltf"))
entity32782.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity32712 = new Entity("Cube_011")
entity32712.setParent(entity32600)
entity32712.addComponent(new Transform({ position: new Vector3(-7.849312, 8.45981, -4.598763) }))
entity32712.getComponent(Transform).rotation.set(0.2357263, 0.6666582, 0.6666582, -0.2357263)
entity32712.getComponent(Transform).scale.set(2.751107, 2.751107, 2.751106)
entity32712.addComponent(new GLTFShape("./unity_assets/entity32712.gltf"))
entity32712.getComponent(Transform).rotation.set(0.6666581, 0.2357263, -0.2357263, 0.6666583)
var entity32566 = new Entity("Cube_012")
entity32566.setParent(entity32600)
entity32566.addComponent(new Transform({ position: new Vector3(-7.849312, 8.45981, -4.598763) }))
entity32566.getComponent(Transform).rotation.set(0.2357263, 0.6666582, 0.6666582, -0.2357263)
entity32566.getComponent(Transform).scale.set(2.751107, 2.751107, 2.751106)
entity32566.addComponent(new GLTFShape("./unity_assets/entity32566.gltf"))
entity32566.getComponent(Transform).rotation.set(0.6666581, 0.2357263, -0.2357263, 0.6666583)
var entity32658 = new Entity("Cube_013")
entity32658.setParent(entity32600)
entity32658.addComponent(new Transform({ position: new Vector3(12.11426, 5.309812, -3.49059) }))
entity32658.getComponent(Transform).rotation.set(-0.6806849, -0.1914894, -0.1914894, 0.6806849)
entity32658.getComponent(Transform).scale.set(0.1367972, 0.1367972, 0.1367972)
entity32658.addComponent(new GLTFShape("./unity_assets/entity32658.gltf"))
entity32658.getComponent(Transform).rotation.set(-0.1914894, -0.680685, 0.6806848, -0.1914895)
var entity32958 = new Entity("Cube_019")
entity32958.setParent(entity32600)
entity32958.addComponent(new Transform({ position: new Vector3(0.1646543, 5.259673, -5.59996) }))
entity32958.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity32958.getComponent(Transform).scale.set(0.1243247, 0.1243247, 0.1243247)
entity32958.addComponent(new GLTFShape("./unity_assets/entity32958.gltf"))
entity32958.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
var entity32846 = new Entity("box")
entity32846.setParent(entity32520)
entity32846.addComponent(new Transform({ position: new Vector3(-0.7281885, 0.1298423, -2.920463) }))
entity32846.getComponent(Transform).rotation.set(-0.1747413, 0, 0, 0.9846144)
entity32846.getComponent(Transform).scale.set(2.489491, 0.4594609, 2.993707)
entity32846.addComponent(new BoxShape())
entity32846.getComponent(BoxShape).withCollisions = true
var material3496 = new Material()
material3496.albedoColor = new Color3(0.8, 0.8, 0.8)
material3496.metallic = 0
material3496.roughness = 1
material3496.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Gamer/Floor.jpg")
entity32846.addComponent(material3496)

var entity33260 = new Entity("cylinder")
entity33260.setParent(entity32520)
entity33260.addComponent(new Transform({ position: new Vector3(-0.6813383, -3.212592, 0.7820497) }))
entity33260.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33260.getComponent(Transform).scale.set(2.712223, 4.079235, 2.712223)
entity33260.addComponent(new CylinderShape())
entity33260.getComponent(CylinderShape).withCollisions = true
entity33260.addComponent(material3496)

var entity33280 = new Entity("video")
entity33280.setParent(entity32520)
entity33280.addComponent(new Transform({ position: new Vector3(-0.5682278, 2.449601, 2.158779) }))
entity33280.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33280.getComponent(Transform).scale.set(0.6625971, 0.6625971, 0.6625971)

var entity32876 = new Entity("sound(custom node)")
entity32876.setParent(entity32520)
entity32876.addComponent(new Transform({ position: new Vector3(-0.06900024, 2.568, 2.109) }))
entity32876.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity32876.getComponent(Transform).scale.set(1, 1, 1)

var entity33358 = new Entity("credit")
entity33358.setParent(entity32520)
entity33358.addComponent(new Transform({ position: new Vector3(-0.5459995, 1.287, 2.516) }))
entity33358.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity33358.getComponent(Transform).scale.set(0.05583001, 0.05583001, 0.05583001)
entity33358.addComponent(new TextShape())
entity33358.getComponent(TextShape).value = "https://sketchfab\.com/models/691\n45aa6647a42849487b6c3404f5075"
entity33358.getComponent(TextShape).color = new Color3(0, 0, 0)
entity33358.getComponent(TextShape).width = 32
entity33358.getComponent(TextShape).height = 10.88203
entity33358.getComponent(TextShape).fontSize = 912

var entity33302 = new Entity("box (7)")
entity33302.setParent(entity32520)
entity33302.addComponent(new Transform({ position: new Vector3(3.961, 0.001, -4.449) }))
entity33302.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity33302.getComponent(Transform).scale.set(0.9, 0.14604, 0.14604)
entity33302.addComponent(new BoxShape())
entity33302.getComponent(BoxShape).withCollisions = true

var entity33060 = new Entity("Text")
entity33060.setParent(entity33302)
entity33060.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050003) }))
entity33060.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity33060.getComponent(Transform).scale.set(0.05853257, 0.3369948, 0.1082158)
entity33060.addComponent(new TextShape())
entity33060.getComponent(TextShape).value = "out\ of\ range"
entity33060.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity33060.getComponent(TextShape).width = 25.4
entity33060.getComponent(TextShape).height = 3.79186
entity33060.getComponent(TextShape).fontSize = 912

var entity32804 = new Entity("box")
entity32804.setParent(entity32520)
entity32804.addComponent(new Transform({ position: new Vector3(5.075, 0.968467, -5.077) }))
entity32804.getComponent(Transform).rotation.set(-0.3696432, 0.09904541, -0.2391173, 0.8923995)
entity32804.getComponent(Transform).scale.set(1, 1, 1)
entity32804.addComponent(new BoxShape())
entity32804.getComponent(BoxShape).withCollisions = true

var entity3126530 = new Entity("AudioSource")
engine.addEntity(entity3126530)
entity3126530.addComponent(new Transform({ position: new Vector3(7.050802, 0.2895149, 2.484241) }))
entity3126530.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity3126530.getComponent(Transform).scale.set(1, 1, 1)

var audioSource = new AudioSource(new AudioClip('unity_assets/Assets/Decentraland/Sample-01/bgm.mp3'))
var playAudioSource3128576 = () => {
  entity3126530.addComponent(audioSource)
  audioSource.playing = true
  audioSource.loop = false
  audioSource.volume = 1
  audioSource.pitch = 1
}

Input.instance.subscribe("BUTTON_UP", e => {
  playAudioSource3128576()
})

