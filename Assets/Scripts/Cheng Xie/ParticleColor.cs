using UnityEngine;
using System.Collections;

public class ParticleColor : MonoBehaviour {
	
	public ParticleSystem Particles;
	
	private ParticleEmitter spawnedParticles;
	private ParticleAnimator particleAnimator;
	
	public bool fireTornado;
	public bool waterTornado;
	public bool lightningTornado;
	public bool sharknado;
	private bool gradientTornado;
	public Material sharkMat;
	public Material waterMat;
	public Material fireMat;
	public Material tornadoMat;
	public Material lightningMat;
	
	private FireTornado ft;
	private SpawnMini lt;
	private Sharknado st;
	//float timer;
	TornadoController c;
//	ParticleSystem m_currentParticleEffect;
//	Particle []ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];

	
	// Use this for initialization
	void Start () {
		c = GameObject.Find ("Tornado").GetComponent<TornadoController>();
		ft = gameObject.GetComponent<FireTornado>();
		lt = gameObject.GetComponent<SpawnMini>();
		st = gameObject.GetComponent<Sharknado>();
		st.enabled = false;
		lt.enabled = false;
//		m_currentParticleEffect = gameObject.particleSystem;
//		ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];
	}
	
	// Update is called once per frame
	void Update () {
		if (c.onWater)
		{
			waterTornado = true;
		}
		else
		{
			waterTornado = false;
		}
		//timer += Time.deltaTime;
		
//		if (Input.GetKeyDown("r"))
//		{
//			gradientTornado = false;
//			fireTornado = !fireTornado;
//		}
//		
//		else if (Input.GetKeyDown("g"))
//		{
//			fireTornado = false;
//			gradientTornado = !gradientTornado;
//		}
		
//		if (gradientTornado)
//		{
//			ParticleSystem m_currentParticleEffect = (ParticleSystem)GetComponent("ParticleSystem");
//			ParticleSystem.Particle []ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];
//			m_currentParticleEffect.GetParticles(ParticleList);
//			
//			//loop through each particle to set the color. I don't like doing it this way...
//			for(int i = 0; i < ParticleList.Length; ++i)
//			{
//			float Life = (ParticleList[i].lifetime / ParticleList[i].startLifetime);
//			ParticleList[i].color = Color.Lerp(Color.red, Color.yellow, Life);
//			} 
//			
//			//manually sets the particles again, this may be expensive
//			m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
//		}
		
		if (fireTornado)
		{
			waterTornado = false;
			SetLightningTornado(false);
			gameObject.particleSystem.renderer.material = fireMat;			
			
			ft.enabled = true;			
		}
		
		else if (waterTornado)
		{
			SetFireTornado(false);
			SetLightningTornado(false);
			c.maxSpeed = 6.0f;		
			c.maxClimbAngle = 60;			
			if (sharknado)
			{
				gameObject.particleSystem.renderer.material = sharkMat;
				st.enabled = true;
				return;
			}
			

			gameObject.particleSystem.renderer.material = waterMat;
			//gameObject.particleSystem.renderer.ParticleSystemRenderMode = ParticleSystemRenderMode.Stretch;

			//c.particleSystem = c.system;
		}
		
		else if (lightningTornado)
		{
			waterTornado = false;
			SetFireTornado (false);	
			gameObject.particleSystem.renderer.material = lightningMat;
			
			lt.enabled = true;
		}
		
		else 
		{
			gameObject.particleSystem.renderer.material = tornadoMat;
			c.maxSpeed = 3.0f;
			c.maxClimbAngle = 60;
			SetFireTornado(false);		
			SetLightningTornado(false);
			SetSharknado(false);
		}
		
	}
	
	public void SetFireTornado(bool active)
	{
		fireTornado = active;
		ft.enabled = active;
		if (active)
		{
			SetLightningTornado(false);
			SetSharknado(false);
		}
	}
	
	public void SetLightningTornado(bool active)
	{
		lightningTornado = active;	
		lt.enabled = active;
		if (active)
		{
			SetFireTornado(false);
			SetSharknado(false);
		}
	}
	
	public void SetSharknado(bool active)
	{
		st.enabled = active;
		
	}
	
}
