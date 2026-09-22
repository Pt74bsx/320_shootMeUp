# Contribuer à Shoot Me Up

## Préparer l'environnement

Le projet cible `net8.0-windows` et utilise Windows Forms. Pour le compiler et le lancer, utilise Windows avec le SDK .NET 8. Le runtime seul ne contient pas les outils de compilation.

Avec Visual Studio, installe la charge de travail « Développement Desktop .NET », puis ouvre `ShootMeUp/ShootMeUp.sln`.

## Compiler depuis la racine du dépôt

```powershell
dotnet --list-sdks
dotnet restore ShootMeUp/ShootMeUp.sln
dotnet build ShootMeUp/ShootMeUp.sln --no-restore
dotnet run --project ShootMeUp/ShootMeUp/ShootMeUp.csproj
```

Si `dotnet` est introuvable, vérifie l'installation du SDK puis ouvre un nouveau terminal.

## Proposer une modification

1. Crée une branche avec un nom qui décrit la modification.
2. Garde chaque pull request centrée sur un changement cohérent.
3. Compile la solution et vérifie manuellement les écrans concernés sous Windows.
4. Décris le problème, la solution et les vérifications réellement effectuées.

Évite de versionner les dossiers générés `bin`, `obj` et `.vs`. Modifie les ressources via les fichiers sources et les outils Visual Studio ; les fichiers `Resources.Designer.cs` sont générés automatiquement.

Pour signaler un problème, joins les étapes de reproduction, le comportement attendu, le comportement observé et le message d'erreur complet en retirant les informations personnelles.
