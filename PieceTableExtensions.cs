

public static class PieceTableExtensions
{
    public static bool AddPiece(this PieceTable pieceTable, Piece piece)
    {
        if (!piece || !pieceTable || pieceTable.m_pieces == null || pieceTable.m_pieces.Contains(piece.gameObject))
        {
            return false;
        }

        pieceTable.m_pieces.Add(piece.gameObject);
        ZLog.Log($"Added Piece {piece.m_name} to PieceTable {pieceTable.name}");

        return true;
    }
}