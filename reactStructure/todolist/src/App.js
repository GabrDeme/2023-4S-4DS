import logo from './logo.svg';
import './App.css';
import { useEffect, useState } from 'react';
import TaskList from './components/List/List';
import Card from './components/Card/Card';
import TaskModal from './components/Modal/Modal';

function formatDate(date) {
  const daysOfWeek = [
    "Domingo",
    "Segunda-Feira",
    "Terça-Feira",
    "Quarta-Feira",
    "Quinta-Feira",
    "Sexta-Feira",
    "Sábado",
  ];

  const months = [
    "Janeiro",
    "Fevereiro",
    "Março",
    "Abril",
    "Maio",
    "Junho",
    "Julho",
    "Agosto",
    "Setembro",
    "Outubro",
    "Novembro",
    "Dezembro",
  ];

  const day = daysOfWeek[date.getDay()];
  const month = months[date.getMonth()];
  const dayNumber = date.getDate();

  return {
    dayOfWeek: day,
    dayNumber: dayNumber,
    month: month,
  };
}

function App() {
  const [tasks, setTasks] = useState([
    // { description: 'Descrição do card 1' },
    // { description: 'Descrição do card 2' },
    // { description: 'Faz o L' },
    // { description: 'Faz o L' },
    // { description: 'Faz o L' },
    // { description: 'Faz o L' },
    // { description: 'Faz o L' }
  ]);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [currentTask, setCurrentTask] = useState(null);
  const [searchText, setSearchText] = useState("");

  const handleAddTask = (task) => {
    setTasks([...tasks, task]);
    setIsModalOpen(false);
  };

  const handleEditTask = (updatedTask) => {
    setTasks(
      tasks.map((task) => (task.id === updatedTask.id ? updatedTask : task))
    );
    setIsModalOpen(false);
  };

  const handleDeleteTask = (taskId) => {
    setTasks(tasks.filter((task) => task.id !== taskId));
  };

  const handleTaskCompleted = (taskId, completed) => {
    setTasks(
      tasks.map((task) => 
        task.id === taskId ? { ...task, completed } : task
      )
    );
  };

  const openModal = (task) => {
    setCurrentTask(task);
    setIsModalOpen(true);
  };

  const filteredTasks = tasks.filter((task) =>
    task.description.toLowerCase().includes(searchText.toLowerCase())
  );

  const today = new Date();
  const { dayOfWeek, dayNumber, month } = formatDate(today);

  return (
    <div className="App">
      <main className="App-body">
        <section className="List-card">
          <h1>
            {dayOfWeek}, <span className="day-number">{dayNumber}</span> de {month}
          </h1>
          <input
            type="text"
            placeholder="Search task"
            className="Input-card"
            value={searchText}
            onChange={(e) => setSearchText(e.target.value)}
          ></input>
          {/* <img src="" alt="Search in the list" /> */}
          <TaskList
            tasks={filteredTasks}
            onEdit={openModal}
            onDelete={handleDeleteTask}
          //handleTaskCompleted
          />
        </section>
        <button
          className="New-card"
          onClick={() => openModal(null)}
        >
          New task
        </button>
        {isModalOpen && (
          <TaskModal
            // onClose={() => setIsModalOpen(false)}
            // onSave={currentTask ? handleEditTask : handleAddTask}
            // currentTask={currentTask}
            tasks={filteredTasks}
            onEdit={openModal}
            onDelete={handleDeleteTask}
          />
        )}
      </main>
    </div>
  );
}

export default App;
