﻿using UnityEngine;
using System.Collections;

/**
 * Extension methods for the Object class
 */

public static class ObjectExtensions  {

	/**
	 * A simplified version of Object.FindObjectOfType() that eliminates the need for type-casting.
	 */

	public static T FindObjectOfType<T>(this Object o) where T : Object {
		return (T) Object.FindObjectOfType (typeof(T));
	}
		
}
