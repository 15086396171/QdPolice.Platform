/**
 * Created by huanghx on 2017/6/21.
 */
class Config {
  constructor() {
    this.isDebug = process.env.NODE_ENV;
    this.apiHost = this.isDebug === 'production' ? '' : 'http://localhost:61567';

  }
}

export default new Config()
