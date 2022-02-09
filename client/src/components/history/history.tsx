import * as React from 'react';
import downloadIcon from '../../images/download_icon.svg';
import deleteIcon from '../../images/delete_icon.svg';
import Modal from '../modal/modal';
import { IStory, IUser } from '../../store/types';
import './history.css';

interface IProps {
  users: IUser[];
  stories: IStory[];
  isOwner: boolean;
}

interface IState {
  showModal: boolean,
  story: IStory | null
}


class History extends React.Component<IProps, IState> {
  constructor(props: IProps) {
    super(props);
    this.state = { showModal: false, story: null };

    this.handleClose = this.handleClose.bind(this);
    this.handleClick = this.handleClick.bind(this);
  }

  public handleClick(story: IStory) {
    this.setState({ showModal: true, story: story });
  }

  public handleClose() {
    this.setState({ showModal: false, story: null });
  }

  public renderHistory(stories: IStory[], isOwner: boolean) {
    return (
      stories.map((story) => {
        if (story.average != null) {
          return (
            <tr key={story.name} className="table__tr history__tr" onClick={() => { this.handleClick(story) }}>
              <td className="history__name">{story.name}</td>
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
            <div className="header__mark">{this.props.stories.length}</div>
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
            {this.renderHistory(this.props.stories, this.props.isOwner)}
          </tbody>
        </table>
        {this.state.story != null && <Modal votes={this.state.story.votes} users={this.props.users} onClose={this.handleClose} />}
      </div>
    );
  }
}

export default History;