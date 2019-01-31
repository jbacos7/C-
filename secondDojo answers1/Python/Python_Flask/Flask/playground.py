from flask import Flask, render_template
app = Flask(__name__)
@app.route('/play')
def index():
    return render_template("index1.html", phrase="Here are my boxes", times=0, p="this works!")


if __name__=="__main__":
    app.run(debug=True)
