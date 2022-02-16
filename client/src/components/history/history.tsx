import * as React from 'react';
import downloadIcon from '../../images/download_icon.svg';
import deleteIcon from '../../images/delete_icon.svg';
import Modal from '../modal/modal';
import { ICard, IDiscussion, IUser } from '../../store/types';
import './history.css';

interface IProps {
  users: IUser[];
  discussions: IDiscussion[];
  isOwner: boolean;
  gradesConverter: (grades: Record<string, string> | null | undefined, cards: ICard[]) => Record<string, number> | null;
  calcAverage: (grades: Record<string, number> | null) => number;
  cards: ICard[] | null;
}

interface IState {
  showModal: boolean,
  discussion: IDiscussion | null
}

interface IModalDiscussion {
  name: string,
  grades: Record<string, number>,
}

class History extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = { showModal: false, discussion: null };

    this.handleClose = this.handleClose.bind(this);
    this.handleClick = this.handleClick.bind(this);
  }

  private getDiscussionInfo(discussion: IDiscussion, cards: ICard[]): IModalDiscussion | null {
    const convertGrades = this.props.gradesConverter(discussion.grades, cards);
    if (convertGrades) {
      return {
        name: discussion.name,
        grades: convertGrades
      };
    }
    return null;
  }

  private getDicussionCount(discussions: IDiscussion[]) {
    let count = 0;
    discussions.forEach(discussion => discussion.endDateTime ? count++ : count += 0);
    return count;
  }

  private handleClick(discussion: IDiscussion) {
    this.setState({ showModal: true, discussion: discussion });
  }

  private handleClose() {
    this.setState({ showModal: false, discussion: null });
  }

  public renderHistory(discussions: IDiscussion[], isOwner: boolean) {
    return (
      discussions.reverse().map((discussion) => {
        if (discussion.endDateTime != null) {
          return (
            <tr key={discussion.name} className="table__tr history__tr" onClick={() => { this.handleClick(discussion) }}>
              <td className="history__name">{discussion.name}</td>
              <td className="history__average">{this.props.cards && this.props.calcAverage(this.props.gradesConverter(discussion.grades, this.props.cards))}</td>
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
        }
        else {
          return null;
        }
      })
    );
  }

  public render() {
    return (
      <div className="history">
        <header className="history__header">
          <div className="history__title">
            <p>Completed Stories</p>
            <div className="header__mark">{this.getDicussionCount(this.props.discussions)}</div>
          </div>
          {this.props.isOwner &&
            <button className="history__button">
              <img className="history__icon" src={downloadIcon} alt="Download" />
              <span className="visual-hidden">Download</span>
            </button>
          }
        </header>
        <table className="table history__table">
          <tbody>
            {this.renderHistory(this.props.discussions, this.props.isOwner)}
          </tbody>
        </table>
        {this.state.discussion && this.props.cards && <Modal discussion={this.getDiscussionInfo(this.state.discussion, this.props.cards)} users={this.props.users} onClose={this.handleClose} />}
      </div>
    );
  }
}

export default History;