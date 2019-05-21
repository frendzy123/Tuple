using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
	public float threshold1;
	public float threshold2;
	public float threshold3;
	public float threshold4;
	public float threshold5;

	private Color p1_vis;
	private Color p1_invis;
	private Color p2_vis;
	private Color p2_invis;
	private Color p3_vis;
	private Color p3_invis;
	private Color p4_vis;
	private Color p4_invis;
	private Color p5_vis;
	private Color p5_invis;

    // Start is called before the first frame update
    void Start()
    {
    	p1_vis = this.transform.Find("petal1").gameObject.GetComponent<SpriteRenderer>().color;
    	p1_invis = p1_vis;
    	p1_invis.a = 0f;
        this.transform.Find("petal1").gameObject.GetComponent<SpriteRenderer>().color = p1_invis;
        p2_vis = this.transform.Find("petal2").gameObject.GetComponent<SpriteRenderer>().color;
        p2_invis = p2_vis;
      	p2_invis.a = 0f;
        this.transform.Find("petal2").gameObject.GetComponent<SpriteRenderer>().color = p2_invis;
        p3_vis = this.transform.Find("petal3").gameObject.GetComponent<SpriteRenderer>().color;
        p3_invis = p3_vis;
        p3_invis.a = 0f;
        this.transform.Find("petal3").gameObject.GetComponent<SpriteRenderer>().color = p3_invis;
        p4_vis = this.transform.Find("petal4").gameObject.GetComponent<SpriteRenderer>().color;
        p4_invis = p4_vis;
        p4_invis.a = 0f;
        this.transform.Find("petal4").gameObject.GetComponent<SpriteRenderer>().color = p4_invis;
        p5_vis = this.transform.Find("petal5").gameObject.GetComponent<SpriteRenderer>().color;
        p5_invis = p5_vis;
        p5_invis.a = 0f;
        this.transform.Find("petal5").gameObject.GetComponent<SpriteRenderer>().color = p5_invis;
    }

    // Update is called once per frame
    void Update()
    {
    	if (score.playerScore < threshold1) {														//all petals invisible
    		this.transform.Find("petal1").gameObject.GetComponent<SpriteRenderer>().color = p1_invis;
    		this.transform.Find("petal2").gameObject.GetComponent<SpriteRenderer>().color = p2_invis;
			this.transform.Find("petal3").gameObject.GetComponent<SpriteRenderer>().color = p3_invis;
			this.transform.Find("petal4").gameObject.GetComponent<SpriteRenderer>().color = p4_invis;
			this.transform.Find("petal5").gameObject.GetComponent<SpriteRenderer>().color = p5_invis;
    	}
        else if (score.playerScore >= threshold1 && score.playerScore < threshold2) { 			 	//only petal1 visible
        	this.transform.Find("petal1").gameObject.GetComponent<SpriteRenderer>().color = p1_vis;
        	this.transform.Find("petal2").gameObject.GetComponent<SpriteRenderer>().color = p2_invis;
        }
        else if (score.playerScore >= threshold2 && score.playerScore < threshold3) {		 		//only petal2 visible
        	this.transform.Find("petal1").gameObject.GetComponent<SpriteRenderer>().color = p1_invis;
			this.transform.Find("petal2").gameObject.GetComponent<SpriteRenderer>().color = p2_vis;
			this.transform.Find("petal3").gameObject.GetComponent<SpriteRenderer>().color = p3_invis;
        }
        else if (score.playerScore >= threshold3 && score.playerScore < threshold4) {		 		//only petal3 visible
        	this.transform.Find("petal2").gameObject.GetComponent<SpriteRenderer>().color = p2_invis;
			this.transform.Find("petal3").gameObject.GetComponent<SpriteRenderer>().color = p3_vis;
			this.transform.Find("petal4").gameObject.GetComponent<SpriteRenderer>().color = p4_invis;
        }
        else if (score.playerScore >= threshold4 && score.playerScore < threshold5) {		 		//only petal4 visible
        	this.transform.Find("petal3").gameObject.GetComponent<SpriteRenderer>().color = p3_invis;
			this.transform.Find("petal4").gameObject.GetComponent<SpriteRenderer>().color = p4_vis;
			this.transform.Find("petal5").gameObject.GetComponent<SpriteRenderer>().color = p5_invis;
        }
        else if (score.playerScore >= threshold5) {											 		//only petal5 visible
        	this.transform.Find("petal4").gameObject.GetComponent<SpriteRenderer>().color = p4_invis;
			this.transform.Find("petal5").gameObject.GetComponent<SpriteRenderer>().color = p5_vis;
        }
    }
}
