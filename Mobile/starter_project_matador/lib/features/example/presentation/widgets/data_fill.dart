import 'package:flutter/material.dart';
import 'input_box.dart';
import 'signup_button.dart';
import 'login_text_at_the _end.dart';

class DataFillBox extends StatelessWidget {
  const DataFillBox({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height,
      width: double.infinity,
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.only(
          topLeft:
              Radius.circular((28 / 812) * MediaQuery.of(context).size.height),
          topRight:
              Radius.circular((28 / 812) * MediaQuery.of(context).size.height),
        ),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Padding(
            padding: EdgeInsets.fromLTRB(
                (41.0 / 375) * MediaQuery.of(context).size.width,
                (32.0 / 812) * MediaQuery.of(context).size.height,
                0.0,
                0.0),
            child: Text(
              'WELCOME',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w400,
                fontSize: (24 / 812) * MediaQuery.of(context).size.height,
                color: Color(0xff0D253C),
              ),
            ),
          ),
          SizedBox(height: (16 / 812) * MediaQuery.of(context).size.height),
          Padding(
            padding: EdgeInsets.fromLTRB(
                (40.0 / 375) * MediaQuery.of(context).size.width,
                (12 / 812) * MediaQuery.of(context).size.height,
                0.0,
                0.0),
            child: Text(
              'Provide credentials to signup',
              style: TextStyle(
                fontFamily: 'Poppins',
                fontWeight: FontWeight.bold,
                fontSize: (14 / 812) * MediaQuery.of(context).size.height,
                color: Color(0xff2D4379),
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (37 / 812) * MediaQuery.of(context).size.height,
                left: (40 / 375) * MediaQuery.of(context).size.width),
            child: Text(
              'Username',
              style: TextStyle(
                  fontFamily: 'Urbanist',
                  fontStyle: FontStyle.italic,
                  fontWeight: FontWeight.w100,
                  fontSize: (14 / 812) * MediaQuery.of(context).size.height,
                  height: (1.21 / 812) *
                      MediaQuery.of(context)
                          .size
                          .height // This corresponds to a line-height of 17px
                  ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: 14 / 812 * MediaQuery.of(context).size.height,
                left: 41 / 375 * MediaQuery.of(context).size.width,
                right: 40 / 375 * MediaQuery.of(context).size.width),
            child: LabelledTextField(
              obscureText: false,
              hintText: 'abebe@gmail.com',
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (20 / 812) * MediaQuery.of(context).size.height,
                left: (40 / 375) * MediaQuery.of(context).size.width),
            child: Text(
              'Password',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontStyle: FontStyle.italic,
                fontWeight: FontWeight.w100,
                fontSize: (14 / 812) * MediaQuery.of(context).size.height,
                height: (1.21 / 812) *
                    MediaQuery.of(context)
                        .size
                        .height, // This corresponds to a line-height of 17px
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: 20 / 812 * MediaQuery.of(context).size.height,
                left: (40 / 375) * MediaQuery.of(context).size.width,
                right: (40 / 375) * MediaQuery.of(context).size.width),
            child: LabelledTextField(
              hintText: '',
              obscureText: true,
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (110 / 812) * MediaQuery.of(context).size.height,
                left: (40.0 / 375) * MediaQuery.of(context).size.width,
                right: (40 / 375) * MediaQuery.of(context).size.width),
            child: Button(),
          ),
          Padding(
            padding: EdgeInsets.only(
              top: (10 / 812) * MediaQuery.of(context).size.height,
            ),
            child: TextAtTheEnd(),
          ),
        ],
      ),
    );
  }
}
