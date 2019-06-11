using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elements;

namespace ElementTesting
{
    [TestClass]
    public class Testing
    {
        [TestMethod]
        public void Test1()
        {
            Player player1 = new Player(
                // HP
                100,
                // Name
                "Tobias",
                // Player Resistance
                new Resistance(
                    new Element(
                        0, 0, 0.5f, 0.1f, 0, 0, 0, 0
                        )
                        ),
                // Player Weapon
                new Weapon(
                    new Resistance(
                        new Element(
                            0,0,1,0,0,0,0,0
                            )
                            ),
                    new Damage(
                        new Element(
                        0, 0, 1, 0, 0, 0, 0, 0
                        )
                        ),
                // min Damage
                5,
                // max Damage
                13
                )
                );

            Player player2 = new Player(
                100,
                "Arscheierverrecks",
                new Resistance(new Element()),
                new Weapon(new Resistance(), new Damage(), 8, 11)
                );

            player2.Resistance.Resistances.ChangeFire(-1);





                
        }
    }
}
