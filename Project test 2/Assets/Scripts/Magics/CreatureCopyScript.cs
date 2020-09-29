using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class CreatureCopyScript:MagicCore
{
    public EnemyTest creature;

    public CreatureCopyScript(){
        this.name = "Copia de inimigo";
    }

    public override void Action()
    {
        //faltou fazer
    }

    public override string descrition()
    {
        return "Este encanto permitirá que você faça aparecer uma réplica perfeita de qualquer criatura contra a qual você esteja lutando. A réplica terá os mesmos índices de HABILIDADE e ENERGIA e os mesmos poderes do original.Mas a réplica estará sob seu controle, e você poderá, por exemplo, instruí - la para que ataque a criatura original e ficar assistindo a batalha de camarote!";
    }

}
