# Product Requirements Document (PRD)  
## Générateur de mots de passe (Blazor WASM)

### 1. Objectif
Fournir un outil simple et rapide pour générer des mots de passe sécurisés.  
L’application fonctionne côté client, sans backend.  

---

### 2. Utilisateurs cibles
- Utilisateurs souhaitant créer des mots de passe forts pour leurs comptes en ligne.  
- Développeurs ou administrateurs souhaitant générer rapidement des mots de passe temporaires.  

---

### 3. Fonctionnalités principales
1. **Paramètres de génération**
   - Longueur personnalisable (ex. 8–64 caractères).  
   - Inclusion optionnelle de chiffres.  
   - Inclusion optionnelle de caractères spéciaux.  
   - Inclusion optionnelle de lettres majuscules et minuscules.  

2. **Génération de mot de passe**
   - Bouton “Générer” qui produit un mot de passe aléatoire selon les paramètres.  
   - Affichage du mot de passe généré dans une zone de texte sélectionnable.  

3. **Copie rapide**
   - Bouton pour copier le mot de passe dans le presse-papier.  

4. **Interface simple**
   - UI responsive adaptée mobile et desktop.  
   - Retour visuel sur la force du mot de passe (optionnel).  

---

### 4. Fonctionnalités secondaires (optionnelles)
- Historique des mots de passe générés (stockage local via `localStorage`).  
- Génération de plusieurs mots de passe en même temps.  
- Thème clair/sombre.  
- Export en fichier texte.  

---

### 5. Contraintes techniques
- Framework : **Blazor WebAssembly** (C#).  
- UI : simple, Bootstrap ou TailwindCSS.  
- Hébergement : GitHub Pages.  
- Pas de stockage serveur, tout côté client.  

---

### 6. Architecture
- **Components** :
  - `PasswordGenerator.razor` : formulaire des paramètres et affichage du mot de passe.  
  - `StrengthIndicator.razor` (optionnel) : jauge de sécurité du mot de passe.  

- **Services** :
  - `PasswordService.cs` : logique de génération aléatoire selon les paramètres.  

---

### 7. Flux utilisateur
1. L’utilisateur choisit la longueur et les options (chiffres, caractères spéciaux, majuscules).  
2. L’utilisateur clique sur “Générer”.  
3. Le mot de passe apparaît immédiatement.  
4. L’utilisateur peut le copier ou le régénérer.  

---

### 8. Roadmap
- **MVP (Version 1)** : génération simple avec paramètres de base et copie rapide.  
- **V2** : force du mot de passe, thème clair/sombre, historique.  
- **V3** : génération multiple, export fichier.  

---

### 9. Critères de réussite
- Mot de passe généré aléatoirement selon les paramètres.  
- Interface responsive et intuitive.  
- Fonctionne entièrement côté client sur GitHub Pages.  
