import * as React from 'react';
import ResultsDiagram from '../results-diagram/results-diagram';
import DiagramLegend from '../diagram-legend/diagram-legend';
import './results.css';

interface IVote {
  grade: number;
  count: number;
}

interface IProps {
  playersCount: number;
<<<<<<< Updated upstream
  average: number;
  votes: IVote[];
=======
  average: number | null;
  grades: Record<string, number> | null;
>>>>>>> Stashed changes
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