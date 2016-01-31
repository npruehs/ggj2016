// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DestroyObject.cs" company="Slash Games">
//   Copyright (c) Slash Games. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Rituals.Menu
{
    using UnityEngine;

    public class DestroyObject : MonoBehaviour
    {
        #region Public Methods and Operators

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }

        #endregion
    }
}