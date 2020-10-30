/* ============================================
 *              Event System
 * --------------------------------------------
 *      This script controls and handles all
 *  global events needed in Dragon Stones.
 *  ===========================================
 */
namespace Dragon_Stones.Events
{
    using UnityEngine;
    
    public class Global_Event_System : MonoBehaviour
    {
        private void Start()
        {
            //Tick event
            Tick_System.OnTick += delegate (object sender, Tick_System.OnTickEventArgs e)
            {

            };
        }
    }
}