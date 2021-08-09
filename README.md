# C# CLI Note Manager
A cli note-taking application written in C#. Designed for speed and simplicity.

### Design motivation
The architecture is being designed to allow easy and flexible additions of new functionality and commands as well.

### Vision:
Options prompt:
```
CLI Note Taker
Options:
 - Create a note
 - List all notes
 - Read a note
 - Update a note
 - Delete a note

Prompt >
```

Create a note:
  ```
  Enter message. CTRL + S to save. CTRL + D to discard:
  _
  ```
List all notes:
  ```
  0) Hello world - 2021/08/08
  1) Cool world - 2021/08/08
  2) Nice - 2021/08/08
  3) Hello - 2021/08/08
  ```

Update a note:
  ```
  Enter note id:
  ```
  ```
  Enter message. CTRL + S to save. CTRL + D to discard:
  <previous message>
  ```
  Updates timestamp. Keeps order within the database.

Delete a note:
  ```
  Enter note id:
  ```
  ```
  <id>) <message>

  Are you sure you would like to delete this note (yes/n)?
  ```

Todo:
1. Add note persistance.
2. Add support for multiline notes.
3. Add traps for CTRL+S, CTRL+D, and CTRL+C keyboard signals.
