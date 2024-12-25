using NotesApi.Models;

namespace NotesApi.Services
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetById(int id);
        void Add(Note note);
        void Delete(int id);
    }

    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new();

        public IEnumerable<Note> GetAll() => _notes;

        public Note GetById(int id) => _notes.FirstOrDefault(n => n.Id == id);

        public void Add(Note note)
        {
            note.Id = _notes.Any() ? _notes.Max(n => n.Id) + 1 : 1;
            _notes.Add(note);
        }

        public void Delete(int id)
        {
            var note = GetById(id);
            if (note != null)
            {
                _notes.Remove(note);
            }
        }
    }
}
