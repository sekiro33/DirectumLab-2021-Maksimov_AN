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
  average: number;
  votes: IVote[];
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