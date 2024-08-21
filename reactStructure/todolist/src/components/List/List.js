import React from 'react';
import Card from '../Card/Card';

function TaskList({ }) {
    const mockData = [
        { id: 1, description: 'Descrição do card 1' },
        { id: 2, description: 'Descrição do card 2' },
        { id: 3, description: 'Faz o L' },
        { id: 4, description: 'Faz o L' },
        { id: 5, description: 'Faz o L' },
        { id: 6, description: 'Faz o L' },
        { id: 7, description: 'Faz o L' }
    ];

    // Estilos para esconder a barra de rolagem
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
    const onTaskCompleted = (taskId) => console.log('Marcar como concluído task com ID', taskId);

    return (
        <ul className="task-list" style={hideScrollbarStyles}>
            {mockData.map((card) => (
                <Card key={card.id} {...card}
                    id={card.id}
                    description={card.description}
                    onEdit={() => onEdit(card)}
                    onDelete={() => onDelete(card.id)}
                    onTaskCompleted={() => onTaskCompleted(card.id)} />
            ))}
        </ul>
    );
}

export default TaskList;
