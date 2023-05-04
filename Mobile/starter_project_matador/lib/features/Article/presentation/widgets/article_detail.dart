import 'package:flutter/material.dart';

class ArticleDetail extends StatelessWidget {
  final String imageUrl;
  final String text;
  final String likes;

  const ArticleDetail(
      {Key? key,
      required this.imageUrl,
      required this.text,
      required this.likes})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;
    return Column(
      children: [
        ClipRRect(
          borderRadius: BorderRadius.only(
              topLeft: Radius.circular(width * 0.06),
              topRight: Radius.circular(width * 0.06)),
          child: Image.asset(
            imageUrl,
            width: double.infinity,
          ),
        ),
        Padding(
          padding: EdgeInsets.all(width * 0.056),
          child: Stack(
            alignment: Alignment.center,
            children: <Widget>[
              // Widgets to position on top of each other
              Expanded(
                child: Text(
                  "very long text goes here. very long text goes here. very long text goes here. very long text goes here.  very long text goes here. very long text goes here. very long text goes here.  very long text goes here. I will copy and paste long text here and see what happens. In the above example, we're using the Stack widget to position two Text widgets on top of each other. We're also using the Positioned widget to specify the position of each Text widget within the Stack. The alignment property of the Stack widget is used to specify the default alignment of the widgets within the Stack. In this case, we're using Alignment.center to center the widgets within the Stack. very long text goes here. I will copy and paste long text here and see what happens. In the above example, we're using the Stack widge to position two Text widgets on top of each other.",
                  style: TextStyle(
                    fontWeight: FontWeight.w400,
                    fontSize: 16,
                  ),
                ),
              ),
              Positioned(
                bottom: height * 0.0542,
                right: width * 0.0453,
                child: ElevatedButton(
                    onPressed: () {},
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Color.fromRGBO(55, 106, 237, 1.0),
                      minimumSize: Size(width * 0.296, height * 0.0591),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(18.0),
                      ),
                    ),
                    child: Row(
                      children: [
                        Icon(Icons.thumb_up_alt_outlined),
                        SizedBox(
                          width: width * 0.0253,
                        ),
                        Text(
                          likes,
                          style: TextStyle(fontSize: 16),
                        )
                      ],
                    )),
              ),
            ],
          ),
        )
      ],
    );
  }
}
