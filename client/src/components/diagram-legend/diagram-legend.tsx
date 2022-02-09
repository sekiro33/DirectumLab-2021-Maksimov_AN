import * as React from 'react';
import cafe from '../../images/cafe.svg';
import { ICard, UserId } from '../../store/types';
import './diagram-legend.css';

interface IProps {
  votes: Record<UserId, ICard>;
}

const DiagramLegend: React.FC<IProps> = (props) => {
  const cafeIcon = () => {
    return (
      <img className='cafe-icon' src={cafe} />
    )
  }

  const getMarker = (grade: number) => {
    if (grade == -10) {
      return '?';
    }
    if (grade == -100) {
      return cafeIcon();
    }
    return grade;
  }

  const getPlayersCount = (votes: Record<UserId, ICard>) => {
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

  const getGradeCount = (votes: Record<UserId, ICard>, value: number) => {
    let count = 0;
    for (const key in votes) {
      if (votes[key].value === value) {
        count++;
      }
    }
    return count;
  }

  const getVoteList = (votes: Record<UserId, ICard>) => {
    const playersCount = getPlayersCount(votes);
    const gradeList = [];
    for (const key in votes) {
      const percent = getGradeCount(votes, votes[key].value) * 100 / playersCount;
      const className = ['grade__marker', getMarkerStyle(votes[key].value)];
      gradeList.push(
        (
          <li key={votes[key].value} className="result">
            <div className="grade">
              <div className={className.join(' ')}></div>
              <span className="grade__text">{getMarker(votes[key].value)}</span>
            </div>
            <p className="result__text">{percent}% ({getGradeCount(votes, votes[key].value)} player)</p>
          </li>)
      );
    }
    
    return gradeList;
  }

  return (
    <ul className="list results__grades">
      {getVoteList(props.votes)}
    </ul>
  )
}

export default DiagramLegend;