Ci dessous la documentation complète de toutes l'Api Logistique.

# Architecture #

L'api est composée de différentes couches qui sont elles même divisée en plusieurs projets.

## La couche Data ##

Elle contient toute la partie accès à une ou plusieurs base de données. 

Elle est composée d'un premier projet de type Bibliothèque de classe, nommé Logistique.Data qui contiendra toutes les classe "repository". Les repository sont les classes dans lesquelles les données de la base de données sont récupérées. Ce sont les seules à pouvoir accéder au contexte, c'est à dire à la base de donnée.

Le deuxième projet de la couche Data contient les interfaces des repository ainsi que toutes les entité nécessaires et leurs interfaces pour une définition générique.

### Les entités ###

Les entités correspondent à chaque tables de la base de données, il y a donc autant d'entités que de tables en base de données.

***Voici la liste de toutes les entités :***

| Nom | Description |
|--------------|-----------|
| PartEntity | Entité des articles |
| DeliveryEntity | Entité des réceptions |
| DeliveryLinesEntity | Entité des lignes de réceptions |
| StockEntity | Entité du stock |
| StockTransactionHistoryEntity | Entité de l'historique des transactions de stock

### Les entités générique ###

Chaque entité crée hérite d'une entité générique qui permet de définir des attributs commun à toutes ces entités une seule et unique fois.

### Les repository ###

Ils servent à récupérer, ajouter, modifier ou supprimer la donnée présente en base.
C'est le seul à avoir accès à la base de donnée.

***Voici la liste des repository :***

| Nom | Description |
|--------------|-----------|
| PartRepository | Repository des articles |
| DeliveryRepository | Repository des réceptions |
| StockRepository | Repository du stock |
| StockTransactionHistoryRepository | Repository de l'historique des transactions de stock

Chaque repository a son interface respective ou se trouve la définition de chaque méthode du repository.