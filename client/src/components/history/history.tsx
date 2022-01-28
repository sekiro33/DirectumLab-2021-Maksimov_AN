import * as React from 'react';
import downloadIcon from '../../images/download_icon.svg';
import deleteIcon from '../../images/delete_icon.svg';
import './history.css';

interface IHistory {
  storyName: string;
  average: number;
}

interface IProps {
  history: IHistory[];
  isOwner: boolean;
}

const createHistory = (history: IHistory[], isOwner: boolean) => {
  return (
    history.map((story) => {
      return (
        <tr key={story.storyName} className="table__tr history__tr">
          <td className="history__name">{story.storyName}</td>
          <td className="history__average">{story.average}</td>
          <td className="history__remove">
            {isOwner &&
              <button className="history__delete-button">
                <img className="history__delete-icon" src={deleteIcon} alt="Remove" />
                <span className="visual-hidden">Remove</span>
              </button>
            }
          </td>
        </tr>
      );
    })
  );
}

const History: React.FC<IProps> = (props) => {
  return (
    <div className="history">
      <header className="history__header">
        <div className="history__title">
          <p>Completed Stories</p>
          <div className="header__mark">{props.history.length}</div>
        </div>
        {props.isOwner &&
          <button className="history__button">
            <img className="history__icon" src={downloadIcon} alt="Download" />
            <span className="visual-hidden">Download</span>
          </button>
        }
      </header>
      <table className="table history__table">
        <tbody>
          {createHistory(props.history, props.isOwner)}
        </tbody>
      </table>
    </div>
  );
}

export default History;