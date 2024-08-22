import { useState } from "react";
import Card from "../Card/Card";

function TaskList({ }) {

    const [tasks, setTasks] = useState([
        // { description: 'Descrição do card 1' },
        // { description: 'Descrição do card 2' },
        // { description: 'Faz o L' },
        // { description: 'Faz o L' },
        // { description: 'Faz o L' },
        // { description: 'Faz o L' },
        // { description: 'Faz o L' }
      ]);

    //Hiding the Scroll bar
    const hideScrollbarStyles = {
        overflowY: 'scroll',
        scrollbarWidth: 'none',
        msOverflowStyle: 'none',
        WebkitScrollbar: {
            width: '0px',
        },
    };

    // Funções de manipulação de eventos (exemplo)
    const onEdit = (task) => console.log('Editar task', task.id);
    const onDelete = (taskId) => console.log('Deletar task com ID', taskId);

    return (
        <ul className="task-list" style={hideScrollbarStyles}>
            {tasks.map((task) => (
                <Card
                    key={task.id}
                    task={task}
                    onEdit={() => onEdit(task)}
                    onDelete={() => onDelete(task.id)}
                />
            ))}
        </ul>
    );
}

export default TaskList;
