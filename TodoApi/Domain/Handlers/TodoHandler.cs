using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Domain.Commands;
using TodoApi.Domain.Commands.Contracts;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Handlers.Contracts;
using TodoApi.Domain.Repositories;

namespace TodoApi.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository repository)
        {
            _todoRepository = repository;
        }


        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail fast validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Gera o TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Salva no banco
            _todoRepository.Create(todo);

            //retorna o resultado
            return new GenericCommandResult(true, "Tarefa criada com sucesso", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            //Busca o todo
            var todo = _todoRepository.GetById(command.Id, command.User);

            //Faz o update
            todo.UpdateTitle(command.Title);

            return new GenericCommandResult(true, "Tarefa atualizada com sucesso", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            //Fail Fast Validation
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            //Fail Fast Validation
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
