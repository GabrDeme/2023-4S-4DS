import React from 'react';
import './Card.css';

function Card({ title, description, image }) {
    return (
        <div className="Card">
            <div className="Check-box">
                {/* <img src="./images/ph_x-bold.svg" alt="Delete item from list" /> */}
            </div>
            <p>{description}</p>
            <div className="Container">
                <div className="Check-box">
                    {/* <img src="./images/ph_x-bold.svg" alt="Delete item from list" /> */}
                </div>
                <div className="Check-box">
                    {/* <img src="./images/mingcute_pencil-fill.svg" alt="Edit item from list" /> */}
                </div>
            </div>
        </div>
    );
}

export default Card;