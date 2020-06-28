﻿using UnityEngine;
using System.Collections;

/**
 * Extension methods for the Rect class
 */

public static class RectExtensions  {


	/**
	 * Get corners of the rect
	 */

	public static Vector2 Corner(this Rect r, int i) {
		Vector2 p = Vector2.zero;

		switch ((i % 4) + 4 % 4) {
		case 0:
			p = r.min;
			break;
		case 1:
			p = new Vector2(r.xMin, r.yMax);
			break;
		case 2:
			p = r.max;
			break;
		case 3:
			p = new Vector3(r.xMax, r.yMin);
			break;
		}


		return p;
	}

	/**
	 * Clamp a Vector2 to lie within the rect
	 */

	public static Vector2 Clamp(this Rect r, Vector2 v) {
		v.x = Mathf.Clamp(v.x, r.xMin, r.xMax);
		v.y = Mathf.Clamp(v.y, r.yMin, r.yMax);
		return v;
	}


	/**
	 * Clamp a Vector3 to lie within the rect
	 */

	public static Vector3 Clamp(this Rect r, Vector3 v) {
		v.x = Mathf.Clamp(v.x, r.xMin, r.xMax);
		v.y = Mathf.Clamp(v.y, r.yMin, r.yMax);
		return v;
	}

	/**
	 * Lerp between two Rects
	 */

	public static Rect Lerp(Rect r1, Rect r2, float t) {
		Rect r = new Rect();

		r.xMin = Mathf.Lerp(r1.xMin, r2.xMin, t);
		r.xMax = Mathf.Lerp(r1.xMax, r2.xMax, t);
		r.yMin = Mathf.Lerp(r1.yMin, r2.yMin, t);
		r.yMax = Mathf.Lerp(r1.yMax, r2.yMax, t);

		return r;
	}
}
