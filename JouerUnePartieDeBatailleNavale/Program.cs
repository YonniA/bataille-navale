    using MoteurDeBatailleNavale;


    Console.WriteLine("Bataille navale");
    Console.WriteLine("Bonjour joueur 1 ");
    UnJoueurHumain joueur1 = new
    UnJoueurHumain("joueur1");
    Console.WriteLine("Bonjour joueur 2 ");
    UnJoueurRobotPasTrèsIntelligent joueur2 = new
    UnJoueurRobotPasTrèsIntelligent("ordi");
    PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1,
   joueur2);
    bool nouvellePartie;
    do
    {
        partie.ChoisirLesRôlesDeDépartDesJoueurs();
        Console.WriteLine("Le joueur {0} est le premier attaquant",partie.Attaquant.Pseudo);
       
        partie.PréparerLaBataille();
        Console.WriteLine("La partie commence maintenant");
        partie.JouerLaPartie();

        Console.WriteLine("Nouvelle partie ? (O/N) :");
        ConsoleKeyInfo keyinfo = Console.ReadKey();
        if (keyinfo.KeyChar == 'O' || keyinfo.KeyChar == 'o')
            nouvellePartie = true;
        else
            nouvellePartie = false;
    }
    while (nouvellePartie);
