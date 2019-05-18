const entity14604 = new Entity() //Main Camera
engine.addEntity(entity14604)
entity14604.addComponent(new Transform({ position: new Vector3(0, 1, -10) }))
entity14604.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14604.getComponent(Transform).scale.set(1, 1, 1)

const entity14426 = new Entity() //Directional Light
engine.addEntity(entity14426)
entity14426.addComponent(new Transform({ position: new Vector3(1.341, 6.197, -2.323) }))
entity14426.getComponent(Transform).rotation.set(0.4082179, -0.2345697, 0.1093816, 0.8754261)
entity14426.getComponent(Transform).scale.set(1, 1, 1)

const entity15190 = new Entity() //Frame
engine.addEntity(entity15190)
entity15190.addComponent(new Transform({ position: new Vector3(15, 0, 5) }))
entity15190.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15190.getComponent(Transform).scale.set(1, 1, 1)

const entity14768 = new Entity() //plane
entity14768.setParent(entity15190)
entity14768.addComponent(new Transform({ position: new Vector3(-5, 3.68928, -4.97) }))
entity14768.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14768.getComponent(Transform).scale.set(19.94, 0.8, 1)
entity14768.addComponent(new PlaneShape())
entity14768.getComponent(PlaneShape).withCollisions = true

const entity14790 = new Entity() //plane (1)
entity14790.setParent(entity15190)
entity14790.addComponent(new Transform({ position: new Vector3(-5, 3.68928, 4.97) }))
entity14790.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14790.getComponent(Transform).scale.set(19.94, 0.8, 1)
entity14790.addComponent(new PlaneShape())
entity14790.getComponent(PlaneShape).withCollisions = true

const entity14514 = new Entity() //plane (2)
entity14514.setParent(entity15190)
entity14514.addComponent(new Transform({ position: new Vector3(-14.97, 3.68928, 0) }))
entity14514.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity14514.getComponent(Transform).scale.set(9.970012, 0.8, 1)
entity14514.addComponent(new PlaneShape())
entity14514.getComponent(PlaneShape).withCollisions = true

const entity15206 = new Entity() //plane (3)
entity15206.setParent(entity15190)
entity15206.addComponent(new Transform({ position: new Vector3(4.97, 3.68928, 0) }))
entity15206.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity15206.getComponent(Transform).scale.set(9.970012, 0.8, 1)
entity15206.addComponent(new PlaneShape())
entity15206.getComponent(PlaneShape).withCollisions = true

const entity14546 = new Entity() //column
entity14546.setParent(entity15190)
entity14546.addComponent(new Transform({ position: new Vector3(-14.958, 2, -4.95) }))
entity14546.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14546.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity14546.addComponent(new BoxShape())
entity14546.getComponent(BoxShape).withCollisions = true

const entity15256 = new Entity() //column (1)
entity15256.setParent(entity15190)
entity15256.addComponent(new Transform({ position: new Vector3(-4.956539, 2, -4.95) }))
entity15256.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15256.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity15256.addComponent(new BoxShape())
entity15256.getComponent(BoxShape).withCollisions = true

const entity15038 = new Entity() //column (2)
entity15038.setParent(entity15190)
entity15038.addComponent(new Transform({ position: new Vector3(4.935, 2, -4.95) }))
entity15038.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15038.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity15038.addComponent(new BoxShape())
entity15038.getComponent(BoxShape).withCollisions = true

const entity14444 = new Entity() //column (4)
entity14444.setParent(entity15190)
entity14444.addComponent(new Transform({ position: new Vector3(-14.958, 2, 4.952) }))
entity14444.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14444.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity14444.addComponent(new BoxShape())
entity14444.getComponent(BoxShape).withCollisions = true

const entity15000 = new Entity() //column (5)
entity15000.setParent(entity15190)
entity15000.addComponent(new Transform({ position: new Vector3(-4.956539, 2, 4.952) }))
entity15000.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15000.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity15000.addComponent(new BoxShape())
entity15000.getComponent(BoxShape).withCollisions = true

const entity15246 = new Entity() //column (6)
entity15246.setParent(entity15190)
entity15246.addComponent(new Transform({ position: new Vector3(4.935, 2, 4.952) }))
entity15246.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15246.getComponent(Transform).scale.set(0.04, 4, 0.04)
entity15246.addComponent(new BoxShape())
entity15246.getComponent(BoxShape).withCollisions = true

const entity14846 = new Entity() //plane (4)
entity14846.setParent(entity15190)
entity14846.addComponent(new Transform({ position: new Vector3(-5, 3.5, -4.98) }))
entity14846.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14846.getComponent(Transform).scale.set(19.94, 0.04, 1)
entity14846.addComponent(new PlaneShape())
entity14846.getComponent(PlaneShape).withCollisions = true
const material3306 = new Material()
material3306.albedoColor = new Color3(0, 0, 0)
material3306.metallic = 0
material3306.roughness = 0.5
material3306.emissiveColor = new Color3(0.04313726, 0, 0.1872549)
entity14846.addComponent(material3306)

const entity14504 = new Entity() //plane (5)
entity14504.setParent(entity15190)
entity14504.addComponent(new Transform({ position: new Vector3(-5, 3.5, 4.98) }))
entity14504.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14504.getComponent(Transform).scale.set(19.94, 0.04, 1)
entity14504.addComponent(new PlaneShape())
entity14504.getComponent(PlaneShape).withCollisions = true
entity14504.addComponent(material3306)

const entity15180 = new Entity() //plane (6)
entity15180.setParent(entity15190)
entity15180.addComponent(new Transform({ position: new Vector3(-14.98, 3.5, 0) }))
entity15180.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity15180.getComponent(Transform).scale.set(9.970014, 0.04, 1)
entity15180.addComponent(new PlaneShape())
entity15180.getComponent(PlaneShape).withCollisions = true
entity15180.addComponent(material3306)

const entity15266 = new Entity() //plane (7)
entity15266.setParent(entity15190)
entity15266.addComponent(new Transform({ position: new Vector3(4.98, 3.5, 0) }))
entity15266.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity15266.getComponent(Transform).scale.set(9.970014, 0.04, 1)
entity15266.addComponent(new PlaneShape())
entity15266.getComponent(PlaneShape).withCollisions = true
entity15266.addComponent(material3306)

const entity14800 = new Entity() //Title
entity14800.setParent(entity15190)
entity14800.addComponent(new Transform({ position: new Vector3(-10, 3.755, -4.999) }))
entity14800.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14800.getComponent(Transform).scale.set(0.1846309, 0.1846309, 0.1846309)
entity14800.addComponent(new TextShape())
entity14800.getComponent(TextShape).value = "DCL\ UNITY\ EXPORTER"
entity14800.getComponent(TextShape).color = new Color3(0.172549, 0, 0.7490196)
entity14800.getComponent(TextShape).width = 32
entity14800.getComponent(TextShape).height = 5.3625
entity14800.getComponent(TextShape).fontSize = 912

const entity14636 = new Entity() //Title (1)
entity14636.setParent(entity15190)
entity14636.addComponent(new Transform({ position: new Vector3(0, 3.755, -4.999) }))
entity14636.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14636.getComponent(Transform).scale.set(0.1846309, 0.1846309, 0.1846309)
entity14636.addComponent(new TextShape())
entity14636.getComponent(TextShape).value = "DCL\ UNITY\ EXPORTER"
entity14636.getComponent(TextShape).color = new Color3(0.172549, 0, 0.7490196)
entity14636.getComponent(TextShape).width = 32
entity14636.getComponent(TextShape).height = 5.3625
entity14636.getComponent(TextShape).fontSize = 912

const entity15138 = new Entity() //roof
entity15138.setParent(entity15190)
entity15138.addComponent(new Transform({ position: new Vector3(-5, 4.1, 0) }))
entity15138.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity15138.getComponent(Transform).scale.set(19.97, 9.98, 1)
entity15138.addComponent(new PlaneShape())
entity15138.getComponent(PlaneShape).withCollisions = true

const entity14762 = new Entity() //Front desk
engine.addEntity(entity14762)
entity14762.addComponent(new Transform({ position: new Vector3(7.106, 0.5, 0.343) }))
entity14762.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14762.getComponent(Transform).scale.set(1, 1, 1)

const entity14980 = new Entity() //plane
entity14980.setParent(entity14762)
entity14980.addComponent(new Transform({ position: new Vector3(-1, 0.06, -0.3309999) }))
entity14980.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14980.getComponent(Transform).scale.set(0.5617885, 0.5617885, 0.5617885)
entity14980.addComponent(new PlaneShape())
entity14980.getComponent(PlaneShape).withCollisions = true
const material3244 = new Material()
material3244.albedoColor = new Color3(0, 0, 0)
material3244.metallic = 0
material3244.roughness = 0.5
material3244.emissiveColor = new Color3(1, 1, 1)
material3244.emissiveTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/fairwood_logo.jpg")
entity14980.addComponent(material3244)

const entity14888 = new Entity() //Table
entity14888.setParent(entity14762)
entity14888.addComponent(new Transform({ position: new Vector3(0, 0, 0) }))
entity14888.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14888.getComponent(Transform).scale.set(3.0906, 1, 0.6410449)
entity14888.addComponent(new BoxShape())
entity14888.getComponent(BoxShape).withCollisions = true
const material3072 = new Material()
material3072.albedoColor = new Color3(0.8962264, 0.8938915, 0.875089)
material3072.metallic = 0
material3072.roughness = 0.11
entity14888.addComponent(material3072)

const entity14660 = new Entity() //plane (8)
entity14660.setParent(entity14888)
entity14660.addComponent(new Transform({ position: new Vector3(0.001, -0.345, -0.5038648) }))
entity14660.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14660.getComponent(Transform).scale.set(1, 0.04, 1.559953)
entity14660.addComponent(new PlaneShape())
entity14660.getComponent(PlaneShape).withCollisions = true
entity14660.addComponent(material3306)

const entity15098 = new Entity() //Text
entity15098.setParent(entity14762)
entity15098.addComponent(new Transform({ position: new Vector3(0.355, 0.04500002, -0.342) }))
entity15098.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15098.getComponent(Transform).scale.set(0.133473, 0.133473, 0.133473)
entity15098.addComponent(new TextShape())
entity15098.getComponent(TextShape).value = "FAIRWOOD"
entity15098.getComponent(TextShape).color = new Color3(0, 0.4627451, 0.09803922)
entity15098.getComponent(TextShape).width = 26.6
entity15098.getComponent(TextShape).height = 5.3625
entity15098.getComponent(TextShape).fontSize = 912

const entity14696 = new Entity() //Map Board
engine.addEntity(entity14696)
entity14696.addComponent(new Transform({ position: new Vector3(1.59, 0, 1.016) }))
entity14696.getComponent(Transform).rotation.set(0, -0.2588186, 0, 0.965926)
entity14696.getComponent(Transform).scale.set(1.3902, 1.3902, 1.3902)

const entity15010 = new Entity() //plane
entity15010.setParent(entity14696)
entity15010.addComponent(new Transform({ position: new Vector3(0, 1.065, 0) }))
entity15010.getComponent(Transform).rotation.set(0.05113563, 0, 0, 0.9986918)
entity15010.getComponent(Transform).scale.set(1, 1, 1)
entity15010.addComponent(new PlaneShape())
entity15010.getComponent(PlaneShape).withCollisions = true
const material3158 = new Material()
material3158.albedoColor = new Color3(1, 1, 1)
material3158.metallic = 0
material3158.roughness = 0.5
material3158.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/dcl_map.png")
entity15010.addComponent(material3158)

const entity15118 = new Entity() //column (8)
entity15118.setParent(entity14696)
entity15118.addComponent(new Transform({ position: new Vector3(-0.25, 0.4, -0.03399992) }))
entity15118.getComponent(Transform).rotation.set(0.03848108, 0.00307059, -0.0794827, 0.9960885)
entity15118.getComponent(Transform).scale.set(0.04000001, 0.8256255, 0.03999999)
entity15118.addComponent(new BoxShape())
entity15118.getComponent(BoxShape).withCollisions = true

const entity15160 = new Entity() //column (9)
entity15160.setParent(entity14696)
entity15160.addComponent(new Transform({ position: new Vector3(0.25, 0.4, -0.034) }))
entity15160.getComponent(Transform).rotation.set(0.03848109, -0.003070428, 0.07947849, 0.9960889)
entity15160.getComponent(Transform).scale.set(0.04000001, 0.8256252, 0.03999999)
entity15160.addComponent(new BoxShape())
entity15160.getComponent(BoxShape).withCollisions = true

const entity14778 = new Entity() //column (10)
entity14778.setParent(entity14696)
entity14778.addComponent(new Transform({ position: new Vector3(0, 0.392, 0.205) }))
entity14778.getComponent(Transform).rotation.set(-0.2456335, 0, 0, 0.9693628)
entity14778.getComponent(Transform).scale.set(0.04, 0.8888682, 0.04)
entity14778.addComponent(new BoxShape())
entity14778.getComponent(BoxShape).withCollisions = true

const entity14594 = new Entity() //column (11)
entity14594.setParent(entity14696)
entity14594.addComponent(new Transform({ position: new Vector3(0, 0.788, -0.004) }))
entity14594.getComponent(Transform).rotation.set(0, 0, 0.7071058, 0.7071078)
entity14594.getComponent(Transform).scale.set(0.04000001, 0.6386578, 0.03999999)
entity14594.addComponent(new BoxShape())
entity14594.getComponent(BoxShape).withCollisions = true

const entity14588 = new Entity() //Area0
engine.addEntity(entity14588)
entity14588.addComponent(new Transform({ position: new Vector3(3.38, 0, 5) }))
entity14588.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14588.getComponent(Transform).scale.set(1, 1, 1)

const entity14690 = new Entity() //Frame
entity14690.setParent(entity14588)
entity14690.addComponent(new Transform({ position: new Vector3(1.93, 0, 0) }))
entity14690.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14690.getComponent(Transform).scale.set(1, 1, 1)

const entity14918 = new Entity() //cylinder
entity14918.setParent(entity14690)
entity14918.addComponent(new Transform({ position: new Vector3(-3.43, 0.4, -1.532) }))
entity14918.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14918.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity14918.addComponent(new CylinderShape())
entity14918.getComponent(CylinderShape).withCollisions = true
const material3360 = new Material()
material3360.albedoColor = new Color3(0.3962264, 0.307827, 0.07662868)
material3360.metallic = 1
material3360.roughness = 0.331
entity14918.addComponent(material3360)

const entity14414 = new Entity() //cylinder (1)
entity14414.setParent(entity14690)
entity14414.addComponent(new Transform({ position: new Vector3(5.57, 0.4, -1.532) }))
entity14414.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14414.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity14414.addComponent(new CylinderShape())
entity14414.getComponent(CylinderShape).withCollisions = true
entity14414.addComponent(material3360)

const entity15216 = new Entity() //cylinder (2)
entity15216.setParent(entity14690)
entity15216.addComponent(new Transform({ position: new Vector3(-3.43, 0.4, 0.89) }))
entity15216.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15216.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity15216.addComponent(new CylinderShape())
entity15216.getComponent(CylinderShape).withCollisions = true
entity15216.addComponent(material3360)

const entity14470 = new Entity() //cylinder (3)
entity14470.setParent(entity14690)
entity14470.addComponent(new Transform({ position: new Vector3(5.57, 0.4, 0.89) }))
entity14470.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14470.getComponent(Transform).scale.set(0.02, 0.4, 0.02)
entity14470.addComponent(new CylinderShape())
entity14470.getComponent(CylinderShape).withCollisions = true
entity14470.addComponent(material3360)

const entity14494 = new Entity() //Tape
entity14494.setParent(entity14690)
entity14494.addComponent(new Transform({ position: new Vector3(1.07, 0.65, -1.532) }))
entity14494.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14494.getComponent(Transform).scale.set(8.986068, 0.08110655, 1)
entity14494.addComponent(new PlaneShape())
const material3304 = new Material()
material3304.albedoColor = new Color3(0.3701339, 0.3436276, 0.6226415)
material3304.metallic = 0
material3304.roughness = 0.5
material3304.hasAlpha = true
material3304.alpha = 0.2784314
entity14494.addComponent(material3304)

const entity14908 = new Entity() //Title (4)
entity14908.setParent(entity14494)
entity14908.addComponent(new Transform({ position: new Vector3(-0.3521428, 0, -0.004700065) }))
entity14908.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14908.getComponent(Transform).scale.set(0.004800823, 0.4143409, 0.03360576)
entity14908.addComponent(new TextShape())
entity14908.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity14908.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity14908.getComponent(TextShape).width = 32
entity14908.getComponent(TextShape).height = 5.3625
entity14908.getComponent(TextShape).fontSize = 912

const entity14750 = new Entity() //Title (5)
entity14750.setParent(entity14494)
entity14750.addComponent(new Transform({ position: new Vector3(-0.1297143, 0, -0.004700065) }))
entity14750.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14750.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity14750.addComponent(new TextShape())
entity14750.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity14750.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity14750.getComponent(TextShape).width = 32
entity14750.getComponent(TextShape).height = 5.3625
entity14750.getComponent(TextShape).fontSize = 912

const entity14898 = new Entity() //Title (6)
entity14898.setParent(entity14494)
entity14898.addComponent(new Transform({ position: new Vector3(0.08285712, 0, -0.004700065) }))
entity14898.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14898.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity14898.addComponent(new TextShape())
entity14898.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity14898.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity14898.getComponent(TextShape).width = 32
entity14898.getComponent(TextShape).height = 5.3625
entity14898.getComponent(TextShape).fontSize = 912

const entity14566 = new Entity() //Title (7)
entity14566.setParent(entity14494)
entity14566.addComponent(new Transform({ position: new Vector3(0.282, 0, -0.004700065) }))
entity14566.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14566.getComponent(Transform).scale.set(0.004801428, 0.4143932, 0.03361)
entity14566.addComponent(new TextShape())
entity14566.getComponent(TextShape).value = "DO\ NOT\ TOUCH"
entity14566.getComponent(TextShape).color = new Color3(1, 0, 0.09019608)
entity14566.getComponent(TextShape).width = 32
entity14566.getComponent(TextShape).height = 5.3625
entity14566.getComponent(TextShape).fontSize = 912

const entity14970 = new Entity() //Tape (1)
entity14970.setParent(entity14690)
entity14970.addComponent(new Transform({ position: new Vector3(1.07, 0.65, 0.89) }))
entity14970.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity14970.getComponent(Transform).scale.set(8.986068, 0.08111, 1)
entity14970.addComponent(new PlaneShape())
entity14970.addComponent(material3304)

const entity15058 = new Entity() //Tape (2)
entity15058.setParent(entity14690)
entity15058.addComponent(new Transform({ position: new Vector3(-3.427, 0.65, -0.323) }))
entity15058.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity15058.getComponent(Transform).scale.set(2.389797, 0.08111, 1)
entity15058.addComponent(new PlaneShape())
entity15058.addComponent(material3304)

const entity15236 = new Entity() //Tape (3)
entity15236.setParent(entity14690)
entity15236.addComponent(new Transform({ position: new Vector3(5.572, 0.65, -0.323) }))
entity15236.getComponent(Transform).rotation.set(0, 0.7071068, 0, 0.7071068)
entity15236.getComponent(Transform).scale.set(2.389802, 0.08111, 1)
entity15236.addComponent(new PlaneShape())
entity15236.addComponent(material3304)

const entity14856 = new Entity() //box
entity14856.setParent(entity14588)
entity14856.addComponent(new Transform({ position: new Vector3(-0.661, 0, -1.064) }))
entity14856.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity14856.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity14856.addComponent(new BoxShape())
entity14856.getComponent(BoxShape).withCollisions = true

const entity14948 = new Entity() //Text
entity14948.setParent(entity14856)
entity14948.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity14948.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14948.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity14948.addComponent(new TextShape())
entity14948.getComponent(TextShape).value = "box"
entity14948.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14948.getComponent(TextShape).width = 7.6
entity14948.getComponent(TextShape).height = 3.79186
entity14948.getComponent(TextShape).fontSize = 912

const entity14990 = new Entity() //box (1)
entity14990.setParent(entity14588)
entity14990.addComponent(new Transform({ position: new Vector3(0.689, 0, -1.064) }))
entity14990.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity14990.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity14990.addComponent(new BoxShape())
entity14990.getComponent(BoxShape).withCollisions = true

const entity15028 = new Entity() //Text
entity15028.setParent(entity14990)
entity15028.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity15028.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15028.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity15028.addComponent(new TextShape())
entity15028.getComponent(TextShape).value = "sphere"
entity15028.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity15028.getComponent(TextShape).width = 14.4
entity15028.getComponent(TextShape).height = 3.79186
entity15028.getComponent(TextShape).fontSize = 912

const entity14732 = new Entity() //box (2)
entity14732.setParent(entity14588)
entity14732.addComponent(new Transform({ position: new Vector3(2.105, 0, -1.064) }))
entity14732.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity14732.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity14732.addComponent(new BoxShape())
entity14732.getComponent(BoxShape).withCollisions = true

const entity14556 = new Entity() //Text
entity14556.setParent(entity14732)
entity14556.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity14556.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14556.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity14556.addComponent(new TextShape())
entity14556.getComponent(TextShape).value = "cylinder"
entity14556.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14556.getComponent(TextShape).width = 16.2
entity14556.getComponent(TextShape).height = 3.79186
entity14556.getComponent(TextShape).fontSize = 912

const entity14958 = new Entity() //box (3)
entity14958.setParent(entity14588)
entity14958.addComponent(new Transform({ position: new Vector3(3.413, 0, -1.064) }))
entity14958.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity14958.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity14958.addComponent(new BoxShape())
entity14958.getComponent(BoxShape).withCollisions = true

const entity14876 = new Entity() //Text
entity14876.setParent(entity14958)
entity14876.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity14876.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14876.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity14876.addComponent(new TextShape())
entity14876.getComponent(TextShape).value = "cone"
entity14876.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14876.getComponent(TextShape).width = 10.2
entity14876.getComponent(TextShape).height = 3.79186
entity14876.getComponent(TextShape).fontSize = 912

const entity14680 = new Entity() //box (4)
entity14680.setParent(entity14588)
entity14680.addComponent(new Transform({ position: new Vector3(4.701, 0, -1.064) }))
entity14680.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity14680.getComponent(Transform).scale.set(0.4868, 0.14604, 0.14604)
entity14680.addComponent(new BoxShape())
entity14680.getComponent(BoxShape).withCollisions = true

const entity14702 = new Entity() //Text
entity14702.setParent(entity14680)
entity14702.addComponent(new Transform({ position: new Vector3(0, 0, -0.505) }))
entity14702.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14702.getComponent(Transform).scale.set(0.1082157, 0.3369947, 0.1082157)
entity14702.addComponent(new TextShape())
entity14702.getComponent(TextShape).value = "plane"
entity14702.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14702.getComponent(TextShape).width = 11.4
entity14702.getComponent(TextShape).height = 3.79186
entity14702.getComponent(TextShape).fontSize = 912

const entity14836 = new Entity() //box
entity14836.setParent(entity14588)
entity14836.addComponent(new Transform({ position: new Vector3(-0.656, 0.423, 0) }))
entity14836.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14836.getComponent(Transform).scale.set(0.8517668, 0.8517668, 0.8517668)
entity14836.addComponent(new BoxShape())
entity14836.getComponent(BoxShape).withCollisions = true
const material2776 = new Material()
material2776.albedoColor = new Color3(1, 1, 1)
material2776.metallic = 0
material2776.roughness = 0.07999998
material2776.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/colormap.png")
entity14836.addComponent(material2776)

const entity15108 = new Entity() //plane
entity15108.setParent(entity14588)
entity15108.addComponent(new Transform({ position: new Vector3(4.826, 0.512, 0) }))
entity15108.getComponent(Transform).rotation.set(0, 0, -0.08550682, 0.9963376)
entity15108.getComponent(Transform).scale.set(0.7253101, 0.7253101, 0.72531)
entity15108.addComponent(new PlaneShape())
entity15108.getComponent(PlaneShape).withCollisions = true
entity15108.addComponent(material2776)

const entity14456 = new Entity() //sphere
entity14456.setParent(entity14588)
entity14456.addComponent(new Transform({ position: new Vector3(0.752, 0.469, 0) }))
entity14456.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14456.getComponent(Transform).scale.set(1, 1, 1)
entity14456.addComponent(new SphereShape())
entity14456.getComponent(SphereShape).withCollisions = true
entity14456.addComponent(material2776)

const entity15088 = new Entity() //cylinder
entity15088.setParent(entity14588)
entity15088.addComponent(new Transform({ position: new Vector3(2.148, 0.479, 0) }))
entity15088.getComponent(Transform).rotation.set(0.1208406, 0, 0, 0.992672)
entity15088.getComponent(Transform).scale.set(0.43202, 0.4320199, 0.4320199)
entity15088.addComponent(new CylinderShape())
entity15088.getComponent(CylinderShape).withCollisions = true
entity15088.addComponent(material2776)

const entity14480 = new Entity() //cone
entity14480.setParent(entity14588)
entity14480.addComponent(new Transform({ position: new Vector3(3.44, 0.646, 0) }))
entity14480.getComponent(Transform).rotation.set(-0.1093272, 0, 0, 0.9940059)
entity14480.getComponent(Transform).scale.set(0.5, 0.5, 0.5)
entity14480.addComponent(new ConeShape())
entity14480.getComponent(ConeShape).withCollisions = true
entity14480.addComponent(material2776)

const entity14722 = new Entity() //box (5)
entity14722.setParent(entity14588)
entity14722.addComponent(new Transform({ position: new Vector3(6.34, 0.48, 0) }))
entity14722.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14722.getComponent(Transform).scale.set(0.6975996, 0.6975996, 0.6975996)
entity14722.addComponent(new BoxShape())
entity14722.getComponent(BoxShape).withCollisions = true
const material2748 = new Material()
material2748.albedoColor = new Color3(1, 0.8428989, 0.06132078)
material2748.metallic = 1
material2748.roughness = 0.43
material2748.bumpTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Materials/bump.jpg")
entity14722.addComponent(material2748)

const entity15048 = new Entity() //box (6)
entity15048.setParent(entity14588)
entity15048.addComponent(new Transform({ position: new Vector3(6.345, 0, -1.064) }))
entity15048.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity15048.getComponent(Transform).scale.set(1.06, 0.14604, 0.14604)
entity15048.addComponent(new BoxShape())
entity15048.getComponent(BoxShape).withCollisions = true

const entity14404 = new Entity() //Text
entity14404.setParent(entity15048)
entity14404.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050002) }))
entity14404.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14404.getComponent(Transform).scale.set(0.04969757, 0.3369948, 0.1082157)
entity14404.addComponent(new TextShape())
entity14404.getComponent(TextShape).value = "special\ material"
entity14404.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14404.getComponent(TextShape).width = 32
entity14404.getComponent(TextShape).height = 3.791861
entity14404.getComponent(TextShape).fontSize = 912

const entity14388 = new Entity() //Area1
engine.addEntity(entity14388)
entity14388.addComponent(new Transform({ position: new Vector3(15.6, 0, 5) }))
entity14388.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14388.getComponent(Transform).scale.set(1, 1, 1)

const entity15196 = new Entity() //box (5)
entity15196.setParent(entity14388)
entity15196.addComponent(new Transform({ position: new Vector3(-2.091, 0.867, -0.725) }))
entity15196.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity15196.getComponent(Transform).scale.set(0.7059714, 0.14604, 0.14604)
entity15196.addComponent(new BoxShape())
entity15196.getComponent(BoxShape).withCollisions = true

const entity14616 = new Entity() //Text
entity14616.setParent(entity15196)
entity14616.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050002) }))
entity14616.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14616.getComponent(Transform).scale.set(0.07461976, 0.3369948, 0.1082158)
entity14616.addComponent(new TextShape())
entity14616.getComponent(TextShape).value = "gltf-model"
entity14616.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14616.getComponent(TextShape).width = 20.8
entity14616.getComponent(TextShape).height = 3.79186
entity14616.getComponent(TextShape).fontSize = 912

const entity14626 = new Entity() //box (6)
entity14626.setParent(entity14388)
entity14626.addComponent(new Transform({ position: new Vector3(-0.606, 1.8781, 1.71) }))
entity14626.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity14626.getComponent(Transform).scale.set(0.5407659, 0.14604, 0.14604)
entity14626.addComponent(new BoxShape())
entity14626.getComponent(BoxShape).withCollisions = true

const entity14866 = new Entity() //Text
entity14866.setParent(entity14626)
entity14866.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050003) }))
entity14866.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14866.getComponent(Transform).scale.set(0.0974161, 0.3369948, 0.1082158)
entity14866.addComponent(new TextShape())
entity14866.getComponent(TextShape).value = "video"
entity14866.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14866.getComponent(TextShape).width = 11.2
entity14866.getComponent(TextShape).height = 3.79186
entity14866.getComponent(TextShape).fontSize = 912

const entity14466 = new Entity() //Gamer_Setup
entity14466.setParent(entity14388)
entity14466.addComponent(new Transform({ position: new Vector3(-0.5608654, 1.0374, 1.317482) }))
entity14466.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity14466.getComponent(Transform).scale.set(0.1754544, 0.1754544, 0.1754544)

const entity14814 = new Entity() //Cube_000
entity14814.setParent(entity14466)
entity14814.addComponent(new Transform({ position: new Vector3(12.11426, 5.309812, -3.49059) }))
entity14814.getComponent(Transform).rotation.set(-0.6806849, -0.1914894, -0.1914894, 0.6806849)
entity14814.getComponent(Transform).scale.set(0.1367972, 0.1367972, 0.1367972)
entity14814.addComponent(new GLTFShape("./unity_assets/entity14814.gltf"))
entity14814.getComponent(Transform).rotation.set(-0.1914894, -0.680685, 0.6806848, -0.1914895)
const entity15078 = new Entity() //Cube_001
entity15078.setParent(entity14466)
entity15078.addComponent(new Transform({ position: new Vector3(0.2170952, -0.5116696, 0.5035708) }))
entity15078.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity15078.getComponent(Transform).scale.set(1, 1, 1)
entity15078.addComponent(new GLTFShape("./unity_assets/entity15078.gltf"))
entity15078.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
const entity14938 = new Entity() //Cube_002
entity14938.setParent(entity14466)
entity14938.addComponent(new Transform({ position: new Vector3(0.1646543, 5.259673, -5.59996) }))
entity14938.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity14938.getComponent(Transform).scale.set(0.1243247, 0.1243247, 0.1243247)
entity14938.addComponent(new GLTFShape("./unity_assets/entity14938.gltf"))
entity14938.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
const entity14648 = new Entity() //Cube_005
entity14648.setParent(entity14466)
entity14648.addComponent(new Transform({ position: new Vector3(10.1875, -0.1889177, -11.27131) }))
entity14648.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity14648.getComponent(Transform).scale.set(2.081236, 2.081236, 2.081236)
entity14648.addComponent(new GLTFShape("./unity_assets/entity14648.gltf"))
entity14648.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
const entity14578 = new Entity() //Cube_011
entity14578.setParent(entity14466)
entity14578.addComponent(new Transform({ position: new Vector3(-7.849312, 8.45981, -4.598763) }))
entity14578.getComponent(Transform).rotation.set(0.2357263, 0.6666582, 0.6666582, -0.2357263)
entity14578.getComponent(Transform).scale.set(2.751107, 2.751107, 2.751106)
entity14578.addComponent(new GLTFShape("./unity_assets/entity14578.gltf"))
entity14578.getComponent(Transform).rotation.set(0.6666581, 0.2357263, -0.2357263, 0.6666583)
const entity14434 = new Entity() //Cube_012
entity14434.setParent(entity14466)
entity14434.addComponent(new Transform({ position: new Vector3(-7.849312, 8.45981, -4.598763) }))
entity14434.getComponent(Transform).rotation.set(0.2357263, 0.6666582, 0.6666582, -0.2357263)
entity14434.getComponent(Transform).scale.set(2.751107, 2.751107, 2.751106)
entity14434.addComponent(new GLTFShape("./unity_assets/entity14434.gltf"))
entity14434.getComponent(Transform).rotation.set(0.6666581, 0.2357263, -0.2357263, 0.6666583)
const entity14524 = new Entity() //Cube_013
entity14524.setParent(entity14466)
entity14524.addComponent(new Transform({ position: new Vector3(12.11426, 5.309812, -3.49059) }))
entity14524.getComponent(Transform).rotation.set(-0.6806849, -0.1914894, -0.1914894, 0.6806849)
entity14524.getComponent(Transform).scale.set(0.1367972, 0.1367972, 0.1367972)
entity14524.addComponent(new GLTFShape("./unity_assets/entity14524.gltf"))
entity14524.getComponent(Transform).rotation.set(-0.1914894, -0.680685, 0.6806848, -0.1914895)
const entity14826 = new Entity() //Cube_019
entity14826.setParent(entity14466)
entity14826.addComponent(new Transform({ position: new Vector3(0.1646543, 5.259673, -5.59996) }))
entity14826.getComponent(Transform).rotation.set(-0.7071068, 0, 0, 0.7071068)
entity14826.getComponent(Transform).scale.set(0.1243247, 0.1243247, 0.1243247)
entity14826.addComponent(new GLTFShape("./unity_assets/entity14826.gltf"))
entity14826.getComponent(Transform).rotation.set(3.090862E-08, -0.7071069, 0.7071068, -3.090862E-08)
const entity14712 = new Entity() //box
entity14712.setParent(entity14388)
entity14712.addComponent(new Transform({ position: new Vector3(-0.7281885, 0.1298423, -2.920463) }))
entity14712.getComponent(Transform).rotation.set(-0.1747413, 0, 0, 0.9846144)
entity14712.getComponent(Transform).scale.set(2.489491, 0.4594609, 2.993707)
entity14712.addComponent(new BoxShape())
entity14712.getComponent(BoxShape).withCollisions = true
const material3496 = new Material()
material3496.albedoColor = new Color3(0.8, 0.8, 0.8)
material3496.metallic = 0
material3496.roughness = 1
material3496.albedoTexture = new Texture("unity_assets/Assets/Decentraland/Sample-01/Gamer/Floor.jpg")
entity14712.addComponent(material3496)

const entity15128 = new Entity() //cylinder
entity15128.setParent(entity14388)
entity15128.addComponent(new Transform({ position: new Vector3(-0.6813383, -3.212592, 0.7820497) }))
entity15128.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15128.getComponent(Transform).scale.set(2.712223, 4.079235, 2.712223)
entity15128.addComponent(new CylinderShape())
entity15128.getComponent(CylinderShape).withCollisions = true
entity15128.addComponent(material3496)

const entity15148 = new Entity() //video
entity15148.setParent(entity14388)
entity15148.addComponent(new Transform({ position: new Vector3(-0.5682278, 2.449601, 2.158779) }))
entity15148.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity15148.getComponent(Transform).scale.set(0.6625971, 0.6625971, 0.6625971)

const entity14742 = new Entity() //sound(custom node)
entity14742.setParent(entity14388)
entity14742.addComponent(new Transform({ position: new Vector3(-0.06900024, 2.568, 2.109) }))
entity14742.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14742.getComponent(Transform).scale.set(1, 1, 1)

const entity15226 = new Entity() //credit
entity15226.setParent(entity14388)
entity15226.addComponent(new Transform({ position: new Vector3(-0.5459995, 1.287, 2.516) }))
entity15226.getComponent(Transform).rotation.set(0, 1, 0, 0)
entity15226.getComponent(Transform).scale.set(0.05583001, 0.05583001, 0.05583001)
entity15226.addComponent(new TextShape())
entity15226.getComponent(TextShape).value = "https://sketchfab\.com/models/691\n45aa6647a42849487b6c3404f5075"
entity15226.getComponent(TextShape).color = new Color3(0, 0, 0)
entity15226.getComponent(TextShape).width = 32
entity15226.getComponent(TextShape).height = 10.88203
entity15226.getComponent(TextShape).fontSize = 912

const entity15170 = new Entity() //box (7)
entity15170.setParent(entity14388)
entity15170.addComponent(new Transform({ position: new Vector3(3.961, 0.001, -4.449) }))
entity15170.getComponent(Transform).rotation.set(0.3826834, 0, 0, 0.9238796)
entity15170.getComponent(Transform).scale.set(0.9, 0.14604, 0.14604)
entity15170.addComponent(new BoxShape())
entity15170.getComponent(BoxShape).withCollisions = true

const entity14928 = new Entity() //Text
entity14928.setParent(entity15170)
entity14928.addComponent(new Transform({ position: new Vector3(0, 0, -0.5050003) }))
entity14928.getComponent(Transform).rotation.set(0, 0, 0, 1)
entity14928.getComponent(Transform).scale.set(0.05853257, 0.3369948, 0.1082158)
entity14928.addComponent(new TextShape())
entity14928.getComponent(TextShape).value = "out\ of\ range"
entity14928.getComponent(TextShape).color = new Color3(0.1254902, 0.1254902, 0.6117647)
entity14928.getComponent(TextShape).width = 25.4
entity14928.getComponent(TextShape).height = 3.79186
entity14928.getComponent(TextShape).fontSize = 912

const entity14670 = new Entity() //box
entity14670.setParent(entity14388)
entity14670.addComponent(new Transform({ position: new Vector3(5.075, 0.968467, -5.077) }))
entity14670.getComponent(Transform).rotation.set(-0.3696432, 0.09904541, -0.2391173, 0.8923995)
entity14670.getComponent(Transform).scale.set(1, 1, 1)
entity14670.addComponent(new BoxShape())
entity14670.getComponent(BoxShape).withCollisions = true

