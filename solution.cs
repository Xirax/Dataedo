[HttpDelete("delete/{id}")]
public string Delete(uint id)
{
    User user = _context.Users.FirstOrDefault(user => user.Id == id);

    if (user == null)
    {
        return $"User with ID {id} not found.";
    }

    _context.Users.Remove(user);
    _context.SaveChanges();
    return $"The user with Login={user.login} has been deleted.";
}