using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VELOCE_RecruitmentTest.Models;

namespace VELOCE_RecruitmentTest.Services.Repositories
{
    public interface IRowRepository
    {
        /// <summary>Gets all RowModel from repository.</summary>
        /// <returns>Enumerable of all rows</returns>
        IEnumerable<RowModel> GetAllRows();

        /// <summary>Gets maximum RowId from all data.</summary>
        /// <returns>Max RowId.</returns>
        int GetMaxId();

        /// <summary>Gets RowModel by given RowID.
        /// Returns null if given RowId not exists.</summary>
        /// <param name="inRowID">Given RowID</param>
        /// <returns>RowModel with given RowId or null if not exists.</returns>
        RowModel GetRowById(int inRowID);

        /// <summary>Delete RowModel of given RowID.
        /// Returns true if given RowId existed and was successfully deleted from data.</summary>
        /// <param name="inRowID">Given RowID</param>
        /// <returns>If operation was successfull</returns>
        bool DeleteRowById(int inRowID);

        /// <summary>Adds given RowModel object to repository.</summary>
        /// <param name="inRow">Given RowModel object</param>
        /// <returns>Added RowModel object.</returns>
        RowModel AddRow(RowModel inRow);

        /// <summary>Updates given RowModel object in repository.
        /// Adds new one if object.RowId not existed in repository.</summary>
        /// <param name="inRow">Given RowModel object</param>
        /// <returns>Updated RowModel object.</returns>
        RowModel UpdateRow(RowModel inRow);
    }
}
