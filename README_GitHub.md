# Как загрузить проект на GitHub

1. Создайте пустой репозиторий на GitHub без `README`, `.gitignore` и лицензии.
2. Откройте Git Bash в корне проекта.
3. Выполните команды:

```bash
git init
git config --global user.name "Ваше Имя"
git config --global user.email "you@example.com"
git add .
git commit -m "lab1: use case model and subject domain"
git branch -M main
git remote add origin https://github.com/USERNAME/tourist-agency-course-project.git
git push -u origin main
```

4. Для поэтапной истории коммитов удобно использовать такую схему:

```bash
git add .
git commit -m "lab2: class diagram and domain model"
git commit -m "lab3: sequence and state diagrams"
git commit -m "lab4: logging and external library"
git commit -m "lab5: nunit tests"
git commit -m "lab6: git history and branches"
git commit -m "lab7: parallel statistics benchmark"
```

5. Для отдельной ветки демонстрации:

```bash
git checkout -b feature/hot-tour-discount
# изменить код
git add .
git commit -m "feature: improve hot tour discount"
git checkout main
git merge feature/hot-tour-discount
```

6. Проверка состояния репозитория:

```bash
git status
git log --oneline --graph --all
```
