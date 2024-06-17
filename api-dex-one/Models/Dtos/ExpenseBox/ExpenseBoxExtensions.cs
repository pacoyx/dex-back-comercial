public static class ExpenseBoxExtensions
{
    public static SelectAllExpenseBoxDto AsSelectAllExpenseBoxDto(this ExpenseBox expenseBox)
    {
        return new SelectAllExpenseBoxDto
        {
            Id = expenseBox.Id,
            CategoryGasto = expenseBox.CategoryGasto,
            PersonalAutoriza = expenseBox.PersonalAutoriza,
            FechaGasto = expenseBox.FechaGasto,
            Importe = expenseBox.Importe,
            DetallesEgreso = expenseBox.DetallesEgreso,
            EstadoRegistro = expenseBox.EstadoRegistro,
        };
    }

    public static ExpenseBox AsExpenseBox(this CreateExpenseBoxDto expenseBox)
    {
        return new ExpenseBox
        {
            CategoryGasto = expenseBox.CategoryGasto,
            PersonalAutoriza = expenseBox.PersonalAutoriza,
            FechaGasto = expenseBox.FechaGasto,
            Importe = expenseBox.Importe,
            DetallesEgreso = expenseBox.DetallesEgreso,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            UsuarioRegistro = expenseBox.UsuarioRegistro,
            UsuarioModificacion = "",
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CompanyId = expenseBox.CompanyId
        };
    }

    public static ExpenseBox AsExpenseBox(this UpdateExpenseBoxDto updateExpenseBoxDto)
    {
        return new ExpenseBox
        {
            Id = updateExpenseBoxDto.Id,
            CategoryGasto = updateExpenseBoxDto.CategoryGasto,
            PersonalAutoriza = updateExpenseBoxDto.PersonalAutoriza,
            FechaGasto = updateExpenseBoxDto.FechaGasto,
            Importe = updateExpenseBoxDto.Importe,
            DetallesEgreso = updateExpenseBoxDto.DetallesEgreso,
            EstadoRegistro = updateExpenseBoxDto.EstadoRegistro,
            UsuarioModificacion = updateExpenseBoxDto.UsuarioModificacion,
            FechaModificacion = DateTime.Now,
        };
    }

}