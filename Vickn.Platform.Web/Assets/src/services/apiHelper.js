/**
 * Created by huanghx on 2017/6/23.
 */

import AuthUtils from '../common/utils/authUtils'
class ApiHelper {
    get(url, param) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                data: param,
                headers: {
                    Authorization: `Bearer ${AuthUtils.getToken()}`
                },
                success(ret) {
                    resolve(ret)
                },
                error (err) {
                    reject(err)
                }
            })
        })
    }

    post(url, param, setting) {
        return new Promise((resolve, reject) => {
            let ajaxParams = Object.assign({}, {
                url: url,
                data: param,
                method: 'POST',
                success(ret) {
                    resolve(ret)
                },
                error (err) {
                    reject(err)
                }
            }, setting)
            $.ajax(ajaxParams)
        })
    }
}

export default new ApiHelper()