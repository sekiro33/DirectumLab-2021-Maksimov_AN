import * as React from 'react';
import ResultsDiagram from '../results-diagram/results-diagram';
import DiagramLegend from '../diagram-legend/diagram-legend';
import './results.css';
import { ICard, UserId } from '../../store/types';

interface IProps {
  playersCount: number;
  average: number | null;
  votes: Record<UserId, ICard>;
}

const Results: React.FC<IProps> = (props) => {
  return (
    <div className='results'>
      <ResultsDiagram playersCount={props.playersCount} average={props.average} />
      <DiagramLegend votes={props.votes} />
    </div>
  )
}

export default Results;