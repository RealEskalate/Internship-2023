import 'package:flutter/material.dart';

class SearchBar extends StatelessWidget {
  const SearchBar({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(20.0),
      child: Material(
        elevation: 3,
        shadowColor: const Color.fromARGB(255, 255, 255, 255),
        borderRadius: BorderRadius.circular(12),
        child: Row(
          children: [
            const Expanded(
              child: TextField(
                decoration: InputDecoration(
                  hintText: 'Search and article...',
                  hintStyle: TextStyle(
                      fontFamily: "Poppins", fontWeight: FontWeight.w100),
                  border: InputBorder.none,
                  contentPadding: EdgeInsets.symmetric(horizontal: 16.0),
                ),
              ),
            ),
            SizedBox(
              height: 50,
              child: ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(12),
                    ),
                  ),
                  onPressed: () {},
                  child: const Icon(Icons.search_outlined)),
            )
          ],
        ),
      ),
    );
  }
}
