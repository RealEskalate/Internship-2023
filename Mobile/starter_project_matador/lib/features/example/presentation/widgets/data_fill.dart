import 'package:flutter/material.dart';
import 'input_box.dart';
import 'signup_button.dart';
import 'login_text_at_the _end.dart';

class DataFillBox extends StatelessWidget {
  const DataFillBox({super.key});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Container(
      height: Height,
      width: double.infinity,
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular((28 / 812) * Height),
          topRight: Radius.circular((28 / 812) * Height),
        ),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Padding(
            padding: EdgeInsets.fromLTRB(
                (41.0 / 375) * Width, (32.0 / 812) * Height, 0.0, 0.0),
            child: Text(
              'WELCOME',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w400,
                fontSize: (24 / 812) * Height,
                color: Color(0xff0D253C),
              ),
            ),
          ),
          SizedBox(height: (16 / 812) * Height),
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
                fontSize: (14 / 812) * Height,
                color: Color(0xff2D4379),
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (37 / 812) * Height, left: (40 / 375) * Width),
            child: Text(
              'Username',
              style: TextStyle(
                  fontFamily: 'Urbanist',
                  fontStyle: FontStyle.italic,
                  fontWeight: FontWeight.w100,
                  fontSize: (14 / 812) * Height,
                  height: (1.21 / 812) *
                      Height // This corresponds to a line-height of 17px
                  ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: 14 / 812 * Height,
                left: 41 / 375 * Width,
                right: 40 / 375 * Width),
            child: LabelledTextField(
              obscureText: false,
              hintText: 'abebe@gmail.com',
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (20 / 812) * Height, left: (40 / 375) * Width),
            child: Text(
              'Password',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontStyle: FontStyle.italic,
                fontWeight: FontWeight.w100,
                fontSize: (14 / 812) * Height,
                height: (1.21 / 812) *
                    Height, // This corresponds to a line-height of 17px
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: 20 / 812 * Height,
                left: (40 / 375) * Width,
                right: (40 / 375) * Width),
            child: LabelledTextField(
              hintText: '',
              obscureText: true,
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (110 / 812) * Height,
                left: (40.0 / 375) * Width,
                right: (40 / 375) * Width),
            child: Button(),
          ),
          Padding(
            padding: EdgeInsets.only(
              top: (10 / 812) * Height,
            ),
            child: Footer(),
          ),
        ],
      ),
    );
  }
}
