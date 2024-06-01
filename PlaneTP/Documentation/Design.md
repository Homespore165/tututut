# Documentation des décisions de désign du projet Avion
## Générateur de scénario
#### Patrons GOF
1. Séparation du logiciel en Vue, Modèle et Controlleur
1. La classe Controlleur implémente le patron Singleton pour empêcher la création de plusieurs instances
1. La classe PlaneFactory implémente le patron Fabrique pour centraliser la création des avions
1. La classe PlaneFactory implémente le patron Singleton pour empêcher la création de plusieurs instances
1. La classe Scénario implémente le patron Facade pour simplifier l'interface avec le modèle
1. Le Patron Obs-Obs est implémenté (On rafraichie la Vue) pour mettre à jour la vue
1. Le Patron Chaine de responsabilité pour créer, modifier et supprimer les avions ainsi que les aéroports pour respecter le principe de responsabilité unique
#### Principes Grasp
1. La classe PlaneFactory implémente le principe créateur pour centraliser la création des avions
1. La classe Controlleur implémente le principe controlleur pour gérer les interactions entre la vue et le modèle
1. La classe Controlleur implémente le principe indirection pour séparer la vue et le modèle
1. Les avions implémentent le principe de polymorphisme pour permettre de traiter les avions de manière générique
## Simulateur 
#### Patrons GOF
1.  Séparation du logiciel en Vue, Modèle et Controlleur
1. La classe Controlleur implémente le patron Singleton pour empêcher la création de plusieurs instances
1. La classe Scénario implémente le patron Facade pour simplifier l'interface avec le modèle
1. Les classes PlaneFactory, ClientSupportFactory et ClientTransportFactory implémentent le patron Fabrique pour centraliser la création des clients
1. Les classes PlaneFactory, ClientSupportFactory et ClientTransportFactory implémentent le patron Singleton pour empêcher la création de plusieurs instances
1. Les classes State et ses enfants implémentent le patron États pour gérer les états des avions
1. Les classes State et ses enfants implémentent le patron Stratégie pour gérer les comportements des avions
1. Le Patron Obs-Obs est implémenté (On rafraichie la Vue) pour mettre à jour la vue
#### Principes Grasp
1. La classe PlaneFactory implémente le principe créateur pour centraliser la création des avions
1. La classe Controlleur implémente le principe controlleur pour gérer les interactions entre la vue et le modèle
1. La classe Controlleur implémente le principe indirection pour séparer la vue et le modèle
1. Les avions implémentent le principe de polymorphisme pour permettre de traiter les avions de manière générique
1. Les états implémentent le principe de polymorphisme pour permettre de traiter les états de manière générique
1. Les Clients implémentent le principe de polymorphisme pour permettre de traiter les clients de manière générique