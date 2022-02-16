import * as React from 'react';
import ResultsDiagram from '../results-diagram/results-diagram';
import DiagramLegend from '../diagram-legend/diagram-legend';
import './results.css';

interface IProps {
  playersCount: number;
  average: number | null;
  grades: Record<string, number> | null;
}

const Results: React.FC<IProps> = (props) => {
  return (
    <div className='results'>
      <ResultsDiagram playersCount={props.playersCount} average={props.average} />
      {props.grades && <DiagramLegend votes={props.grades} />}
    </div>
  )
}

export default Results;