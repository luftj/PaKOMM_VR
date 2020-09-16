from flask import Flask, request
app = Flask(__name__)


@app.route('/')
def hello_world():
    x= float(request.args.get('pos_x').replace(",","."))
    y= float(request.args.get('pos_y').replace(",","."))
    t= request.args.get('type')
    print('success! got %s at (%f,%f)' % (t,x,y))
    return 'success! got %s at (%f,%f)' % (t,x,y)

@app.route('/test')
def test():
	return "test success"

if __name__ == '__main__':
    app.run(host="0.0.0.0",debug=True)
