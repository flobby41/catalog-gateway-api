# ECommerce API

API web ASP.NET Core pour la gestion de produits et catégories d'un e-commerce.

## Prérequis

- .NET 7.0 SDK (ou supérieur)
- Visual Studio 2022, VS Code, ou un autre éditeur compatible

## Configuration

1. Clonez le repository
2. Ouvrez le projet dans Visual Studio ou VS Code
3. Restaurez les packages NuGet :
   ```bash
   dotnet restore ECommerceAPI.csproj
   ```

## Base de données

L'API utilise Entity Framework Core avec **SQLite** pour le développement. La base de données sera créée automatiquement au premier démarrage dans le fichier `ECommerceDB.db`.

### Connection String

La connection string par défaut utilise SQLite :
```
Data Source=ECommerceDB.db
```

> **Note** : Pour utiliser SQL Server en production, modifiez le package NuGet et la connection string dans `appsettings.json`.

## Démarrage

```bash
dotnet run --project ECommerceAPI.csproj
```

L'API sera disponible sur `http://localhost:5000` (ou le port configuré).

## Tester l'API

### Option 1 : Swagger UI (Recommandé)

**Swagger est déjà installé et configuré !** Pas besoin d'installation supplémentaire.

1. Démarrez l'application :
   ```bash
   dotnet run --project ECommerceAPI.csproj
   ```

2. Ouvrez votre navigateur et accédez à :
   ```
   http://localhost:5000/swagger
   ```

3. Vous verrez une interface interactive avec tous les endpoints disponibles. Vous pouvez :
   - Voir tous les endpoints (GET, POST, DELETE)
   - Tester chaque endpoint directement depuis le navigateur
   - Voir les modèles de données (DTOs)
   - Exécuter des requêtes et voir les réponses

### Option 2 : cURL ou Postman

Vous pouvez également tester l'API avec :
- **cURL** (ligne de commande)
- **Postman** (application desktop)
- **Thunder Client** (extension VS Code)
- Votre application frontend (React/Angular)

### Exemples avec cURL

```bash
# Récupérer tous les produits
curl http://localhost:5000/api/products

# Récupérer un produit par ID
curl http://localhost:5000/api/products/1

# Créer un produit
curl -X POST http://localhost:5000/api/products \
  -H "Content-Type: application/json" \
  -d '{"name": "Nouveau Produit", "description": "Description", "price": 199, "image": "/images/test.png", "categories": [1]}'
```

## Endpoints

### Produits

- `GET /api/products` - Récupère tous les produits
- `GET /api/products/{id}` - Récupère un produit par ID
- `GET /api/products?slug={slug}` - Récupère un produit par slug
- `POST /api/products` - Crée un nouveau produit
- `DELETE /api/products/{id}` - Supprime un produit

### Catégories

- `GET /api/categories` - Récupère toutes les catégories avec leurs produits
- `GET /api/categories/{id}` - Récupère une catégorie par ID
- `GET /api/categories?slug={slug}` - Récupère une catégorie par slug
- `POST /api/categories` - Crée une nouvelle catégorie
- `DELETE /api/categories/{id}` - Supprime une catégorie

## Exemples d'utilisation

### Créer un produit

```json
POST /api/products
{
  "name": "T-Shirt",
  "description": "Lorem ipsum dolor",
  "price": 199,
  "image": "/images/t-shirt.png",
  "categories": [1]
}
```

### Créer une catégorie

```json
POST /api/categories
{
  "name": "T-Shirts",
  "image": "/images/t-shirt.png"
}
```

## Fonctionnalités

- Génération automatique de URL-slug
- Relations many-to-many entre produits et catégories
- Validation des données
- Gestion des erreurs HTTP appropriées
- Données de test incluses

## Structure du projet

```
ECommerceAPI/
├── Controllers/          # Contrôleurs API
├── Data/                # Contexte Entity Framework
├── DTOs/                # Data Transfer Objects
├── Models/              # Modèles de données
├── Services/            # Services utilitaires
├── Program.cs           # Point d'entrée de l'application
└── appsettings.json     # Configuration
```

