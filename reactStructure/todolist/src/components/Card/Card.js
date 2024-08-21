import React, { useState } from 'react';
import './Card.css';

function Card({ task, onEdit, onDelete, onTaskCompleted }) {
    const [isChecked, setIsChecked] = useState(task.completed);

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
        onTaskCompleted(task.id); // Notify parent about completed task
    };

    const handleEditClick = () => {
        onEdit(task);
    };

    return (
        <div className="Card">
            <input
                type="checkbox"
                className="Check-b ox"
                checked={isChecked}
                onChange={handleCheckboxChange}
            ></input>

            {/* <img src="./images/ph_x-bold.svg" alt="Delete item from list" /> */}

            <p>{description}</p>
            <section className="Container">

                <button
                    className="Check-box"
                    onClick={handleEditClick}>
                    {/* <img src="./images/ph_x-bold.svg" alt="Delete item from list" /> */}
                </button>

                <button
                    className="Check-box"
                    onClick={() => onDelete(task.id)}>
                    {/* <img src="./images/mingcute_pencil-fill.svg" alt="Edit item from list" /> */}
                </button>

            </section>
        </div>
    );
}

export default Card;