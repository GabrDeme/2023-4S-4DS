import React, { useState, useEffect } from 'react';

function TaskModal({ onClose, onSave, currentTask }) {
  const [description, setDescription] = useState('');

  useEffect(() => {
    if (currentTask) {
      setDescription(currentTask.description);
    } else {
      setDescription('');
    }
  }, [currentTask]);

  const handleSubmit = () => {
    const newTask = {
      id: currentTask ? currentTask.id : Date.now(),
      description,
      completed: currentTask ? currentTask.completed : false,
    };
    onSave(newTask);
  };

  return (
    <div className="modal">
      <div className="modal-content">
        <h2>Descreva sua tarefa</h2>
        <textarea
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder="Exemplo de descrição"
        />
        <button onClick={handleSubmit}>Confirmar tarefa</button>
      </div>
    </div>
  );
}

export default TaskModal;