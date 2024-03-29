import * as React from 'react';
import './results-diagram.css';

interface IProps {
  playersCount: number;
  average: number;
}

const ResultsDiagram: React.FC<IProps> = (props) => {
  return (
    <div className="results__diagram">
      <div className="diagram__info">
        <span className="info__title">{props.playersCount} Playes</span>
        <span className="info__text">voted</span>
        <span className="info__title">Avg: {props.average}</span>
      </div>
    </div>
  );
}

export default ResultsDiagram;