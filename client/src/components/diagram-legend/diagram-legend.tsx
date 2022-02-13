import * as React from 'react';
import cafe from '../../images/cafe.svg';
import './diagram-legend.css';

interface IProps {
  votes: Record<string, number>;
}

const DiagramLegend: React.FC<IProps> = (props) => {
  const getMarker = (grade: number) => {
    if (grade == -10) {
      return '?';
    }
    if (grade == -100) {
      return (<img className='cafe-icon' src={cafe} />);
    }
    return grade;
  }

  const getPlayersCount = (votes: Record<string, number>) => {
    let playersCount = 0;
    for (const key in votes) {
      playersCount++;
    }
    return playersCount;
  }

  const getMarkerStyle = (grade: number) => {
    switch (grade) {
      case 0:
        return 'grade__0';

      case 0.5:
        return 'grade__0.5';

      case 1:
        return 'grade__1';

      case 2:
        return 'grade__2';

      case 3:
        return 'grade__3';

      case 5:
        return 'grade__5';

      case 8:
        return 'grade__8';

      case 13:
        return 'grade__13';

      case 20:
        return 'grade__20';

      case 40:
        return 'grade__40';

      case 100:
        return 'grade__100';

      case -10:
        return 'grade__question';

      case -100:
        return 'grade__cafe';

      default:
        return '';
    }
  }

  const getGradeCount = (votes: Record<string, number>, value: number) => {
    let count = 0;
    for (const key in votes) {
      if (votes[key] === value) {
        count++;
      }
    }
    return count;
  }

  const getVoteList = (votes: Record<string, number>) => {
    const playersCount = getPlayersCount(votes);
    const grades = [];
    for (const key in votes) {
      grades.push(votes[key]);
    }
    const result = Array.from(new Set(grades));
    return result.map((grade) => {
      const percent = (getGradeCount(votes, grade) * 100 / playersCount).toFixed(2);
      const className = ['grade__marker', getMarkerStyle(grade)];
      return (
        <li key={grade} className="result">
          <div className="grade">
            <div className={className.join(' ')}></div>
            <span className="grade__text">{getMarker(grade)}</span>
          </div>
          <p className="result__text">{percent}% ({getGradeCount(votes, grade)} player)</p>
        </li>
      )
    });
  }

  return (
    <ul className="list results__grades">
      {getVoteList(props.votes)}
    </ul>
  )
}

export default DiagramLegend;