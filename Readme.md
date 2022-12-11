Ci dessous la documentation complète de toutes l'Api Logistique.

# Architecture #

L'api est composée de différentes couches qui sont elles même divisée en plusieurs projets.

## La couche Data ##

Elle contient toute la partie accès à une ou plusieurs base de données. 

Elle est composée d'un premier projet de type Bibliothèque de classe, nommé Logistique.Data qui contiendra toutes les classe "repository". Les repository sont les classes dans lesquelles les données de la base de données sont accessibles. Ce sont les seules à pouvoir accéder au contexte, c'est à dire à la base de donnée.

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

Chaque repository a son interface respective ou se trouve la signature de chaque méthode du repository.

## La couche Business ##

Cette couche contient tout la partie de mapping des données extraites de la base en Data Transfert Object (DTO). Les DTO sont les modèle de données qui seront retournée par l'API vers le Front, ce sont donc les données que l'utilisateur pourra visualiser.

La couche est divisée en deux projet distincts. Un projet Logistique.Business de type bibliothèque de classe, qui cotiendra tout les classes "services". Le deuxième projet, nommé "Logistique.Business.Description" contiendra les interfaces de chaque service présent dans le premier projet, ainsi que tous les BusinessModels, équivalent des DTO dans mon architecture.

### Les Services ###

Ils servent à convertir les données retournées par la base de données en données exploitable par l'utilisateur et l'interface utilisateur de l'application. C'est également dans ce type de classes que seront effectuées les traitements de  la données, comme par exemple le remplissage ou la modification de certain atribut de la classe. Ces ajouts et mofication ont notamment lieu lors de l'ajout ou de la modification de données en base.

***Voici la liste des services***

| Nom | Description |
|--------------|-----------|
| PartService | Service des articles |
| DeliveryService | Service des réceptions |
| StockService | Service du stock |
| StockTransactionHistoryService | Service de l'historique des transactions de stock

Chaque service possède sont interface où sont présentes les signatures de toutes les méthodes du service.

### Les DTO, nommées BusinessModels dans mon architecture ###

Les BusinessModels sont les classes qui serviront à l'API pour retourner les données à l'utilisateur et  à l'interface utilisateur de l'application. Ils serviront également à faire transiter les données de l'utilisateur vers l'API.


## La couche WEB ##

Elle est composée d'un projet nommé "Logistique.Web.Api". C'est le point d'entrée de l'API, il contient tous les controllers de l'application.

### Les endpoints de l'API ###

Voici la liste des Endpoints : 

| Url | Description |
|--------------|-----------|
| https://localhost:7091/Auth/login | Endpoint de connection qui permet de récupérer le Token JWT |
| https://localhost:7091/Auth/register | Endpoint qui permet de se créer un compte utilisateur |
| https://localhost:7091/Delivery/GetReceptions | Permet de récupérer toutes les réceptions |
| https://localhost:7091/Delivery/Getbyid | Permet de récupérer une réception selon son id |
| https://localhost:7091/Delivery/Adddelivery | Permet de créer une nouvelle réception |
| https://localhost:7091/Delivery/ConfirmDelivery/{id} | Permet de confirmer une réception |
| https://localhost:7091/Delivery/CancelDelivery/{id} | Permet d'annuler une réception |
| https://localhost:7091/Delivery/UpdateDelivery/{id} | Permet de modifier une réception |
| https://localhost:7091/Delivery/RemoveDeliveryById/{id} | Permet de supprimer une réception |
| https://localhost:7091/Part/GetParts | Permet de récupérer tous les articles |
| https://localhost:7091/Part/getbyid/{id} | Permet de récupérer un article avec son id |
| https://localhost:7091/Part/Addpart| Permet d'ajouter un article |
| https://localhost:7091/Part/UpdatePart/{id}| Permet de modifier un article |
| https://localhost:7091/Part/Removepartbyid/{id}| Permt de supprimer un article |
| https://localhost:7091/Stock/GetStocks | Permet de récupérer tousles stocks |
| https://localhost:7091/Stock/Getstockbypartid/{partId} | Permet de récupérer un stock selon l'id d'un article |
| https://localhost:7091/StockTransactionHistory/GetAll | Permet de récuperer toutes les transactions de stock |
| https://localhost:7091/StockTransactionHistory/GetById/{id} | Permet de récupererune transactionde stock par son id |



