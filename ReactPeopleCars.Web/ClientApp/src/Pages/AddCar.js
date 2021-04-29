import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useHistory, useParams } from 'react-router-dom';

const AddCar = () => {
    const [car, setCar] = useState({ make: '', model: '', year: '' });
    const [person, setPerson] = useState({ firstName: '', lastName: '' });
    

    const history = useHistory();
    const { personId } = useParams();

    useEffect(() => {
        const getPerson = async () => {
            const { data } = await axios.get(`/api/peoplecars/getperson`, { params: { id: personId } });
            setPerson(data);
        }

        getPerson();
    }, [personId]);

    const onTextChange = e => {
        const copy = { ...car };
        copy[e.target.name] = e.target.value;
        setCar(copy);
    }

    const onSubmitClick = async () => {
        const { make, model, year } = car;
        await axios.post('/api/peoplecars/addcar', { make, model, year, personId });
        history.push('/');
    }

    const onRandomClick = async () => {
        const { data } = await axios.get('/api/peoplecars/randompersonid');
        history.push(`/addcar/${data}`);
    }

    const { make, model, year } = car;
    const { firstName, lastName } = person;

    return (
        <div style={{ minHeight: 1000, paddingTop: 300 }}>
            <div className="row">
                <div className='col-md-6 offset-md-3 card card-body bg-light'>
                    {firstName && <h2>Add a car for {firstName} {lastName}</h2>}
                    <input type="text" className='form-control' name='make' value={make} onChange={onTextChange} placeholder="Make" />
                    <br />
                    <input type="text" className='form-control' name='model' value={model} onChange={onTextChange} placeholder="Model" />
                    <br />
                    <input type="text" className='form-control' name='year' value={year} onChange={onTextChange} placeholder="Year" />
                    <br />
                    <button className='btn btn-primary btn-lg btn-block' onClick={onSubmitClick}>Submit</button>
                    <button className='btn btn-danger btn-lg btn-block' onClick={onRandomClick}>Go To Random Person</button>
                </div>
            </div>
        </div>
    )
}

export default AddCar;