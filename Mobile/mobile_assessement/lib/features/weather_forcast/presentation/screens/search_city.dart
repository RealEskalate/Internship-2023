import '../../../../core/utils/colors.dart';
import 'package:flutter/material.dart';

import '../widgets/search_bar.dart';

class SearchCity extends StatelessWidget {
  const SearchCity({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final Size size = MediaQuery.of(context).size;
    return Scaffold(
      backgroundColor: Color(0xFFF2F2F2),
      body: Padding(
        padding: const EdgeInsets.fromLTRB(0, 40, 0, 0),
        child: Column(
          children: [
            Center(
                child: Text(
              "Choose City",
              style: TextStyle(
                  color: Color(0xff211772), fontWeight: FontWeight.bold),
            )),
            SearchBar()
          ],
        ),
      ),
    );
  }
}
