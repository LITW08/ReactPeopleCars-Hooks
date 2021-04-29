import React, { useState } from 'react';
import { produce } from 'immer';
import axios from 'axios';
import { useHistory } from 'react-router-dom';


const AddPerson = () => {
    const [person, setPerson] = useState({ firstName: '', lastName: '', age: '' });
    const history = useHistory();

    const onTextChange = e => {
        const copy = { ...person };
        copy[e.target.name] = e.target.value;
        setPerson(copy);
    }

    const onSubmitClick = async () => {
        await axios.post('/api/peoplecars/addperson', person);
        history.push('/');
    }

    const { firstName, lastName, age } = person;
    return (
        <div style={{ minHeight: 1000, paddingTop: 300 }}>
            <div className="row">
                <div className='col-md-6 offset-md-3 card card-body bg-light'>
                    <h2>Add a New Person</h2>
                    <input type="text"
                        className='form-control'
                        name='firstName'
                        value={firstName}
                        onChange={onTextChange}
                        placeholder="First Name" />
                    <br />
                    <input
                        className='form-control'
                        name='lastName'
                        value={lastName}
                        onChange={onTextChange}
                        placeholder="Last Name" />
                    <br />
                    <input
                        className='form-control'
                        name='age'
                        value={age}
                        onChange={onTextChange}
                        placeholder="Age" />
                    <br />
                    <button className='btn btn-primary btn-lg btn-block' onClick={onSubmitClick}>Submit</button>
                </div>
            </div>
        </div>
    )
}

export default AddPerson;