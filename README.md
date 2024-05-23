[HttpPost("delete/{id}")]
public void Delete(uint id)
{
    User user = _context.Users.FirstOrDefault(user => user.Id == id);
    _context.Users.Remove(user);_context.SaveChanges();
    Debug.WriteLine($"The user with Login={user.login} has been deleted.");
    return Ok();
}

^ STARY KOD ^
Poprawki w Solution.cs


Robiąc to Code Rewiev zwracałem uwagę na czytelność kodu, na zabezpieczenie przed nullami i exceptionami, na to czy w funkcji są elementy, które nie są w niej potrzebne (Robią coś innego niż założenie funkcji). Do czego się "przyczepiłem"? 
1. Mocno musiałem przymknąć oko na to założenie, że rozwiązanie się kompiluje, bo return Ok(); i void w deklaracji na pewno się nie kompilowało :D
2. Atrybut HttpPost raczej tutaj nie pasuje, zmieniamy na HttpDelete
3. Łatwo zauważyć, że jest to metoda API, zatem nie zwracanie żadnej informacji użytkownikowi czy jego akcja się powiodła nie jest najlepszą praktyką. Z powodu małego kontekstu pozwoliłem sobie na zwracanie po prostu stringa
4. Nie wiem co robiła metoda Ok(), mając szerszy kontekst być może bym ją zostawił, tutaj pozwoliłem sobie na kontynuację swojego pomysłu i zwracam po prostu stosowny komunikat
5. Debug.WriteLine już nam nie będzie potrzebny
6. Jeśli nie znajdziemy usera o takim id to zwróci nam nulla, warto to obsłużyć i nie "kłamać", że poszło dobrze
