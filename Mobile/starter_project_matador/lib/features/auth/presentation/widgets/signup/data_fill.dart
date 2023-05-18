import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/constants/styles.dart';
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
      width: Width,
      decoration: BoxDecoration(
        color: profileAvatarCircularRingColor,
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
              style: WelcomeTextStyle,
            ),
          ),
          SizedBox(height: (16 / 812) * Height),
          Padding(
            padding: EdgeInsets.fromLTRB(
                (40.0 / 375) * Width, (12 / 812) * Height, 0.0, 0.0),
            child: Text(
              'Provide credentials to signup',
              style: ProvideCredentialTextStyle,
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
                top: (37 / 812) * Height, left: (40 / 375) * Width),
            child: Text(
              'Username',
              style: UsernameTextStyle,
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
              style: PasswordText,
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
            child: CustomButton(),
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
