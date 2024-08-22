import { useState } from "react";
import './Card.css';

function Card({ task, onEdit, onDelete }) {
    const [isChecked, setIsChecked] = useState(false); // Default to false if 'completed' property is not used

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
        // Assuming onTaskCompleted is handled elsewhere or not needed
    };

    const handleEditClick = () => {
        onEdit(task);
    };

    return (
        <div className="Card">
            <input
                type="checkbox"
                className="Check-box"
                checked={isChecked}
                onChange={handleCheckboxChange}
            ></input>

            <p>{task.description}</p> {/* Make sure to access description via task.description */}
            <section className="Container">
                <button
                    className="Check-box"
                    onClick={handleEditClick}>
                    {/* Edit button content */}
                </button>

                <button
                    className="Check-box"
                    onClick={() => onDelete(task.id)}>
                    {/* Delete button content */}
                </button>
            </section>
        </div>
    );
}

export default Card;
