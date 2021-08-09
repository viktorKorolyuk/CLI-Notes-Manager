using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Data.Sqlite;
using Models;

namespace Database
{
  public class NoteStorage : IDisposable
  {
    private List<Note> storage = new List<Note>();

    public NoteStorage()
    {
      // TODO: Restore the notes.
    }

    /// <summary>
    /// Save a note to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Returns the ID of the note.</returns>
    public int Add(Note entity)
    {
      storage.Add(entity);
      return storage.Count() - 1;
    }

    /// <summary>
    /// Request a note from the database.
    /// No bounds-checking is done on `index`.
    /// </summary>
    /// <param name="index"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <returns></returns>
    public Note Read(int index)
    {
      return storage[index];
    }

    /// <summary>
    /// Get all notes from the database.
    /// </summary>
    /// <returns></returns>
    public IList<Note> GetNotes()
    {
      return storage;
    }

    /// <summary>
    /// Replace a Note at the index within the database.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="entity"></param>
    public void Update(int index, Note entity)
    {
      storage[index] = entity;
    }

    /// <summary>
    /// Delete a note within the database.
    /// No bounds-checking is done on `index`.
    /// </summary>
    /// <param name="index"></param>
    public void Delete(int index)
    {
      storage.RemoveAt(index);
    }

    public void Dispose()
    {
      // TODO: Save the notes
    }
  }
}